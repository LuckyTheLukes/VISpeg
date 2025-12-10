using System.IO;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;

namespace VISpeg
{
    public partial class FormMain : Form
    {
        private FFmpegRunner _ffmpegRunner;

        private readonly HashSet<string> allowedExtensions = new() { ".png", ".jpg", ".jpeg", ".tga", ".targa", ".tif", ".tiff" };
        private int? _inputStartIndex;

        private readonly Dictionary<string, List<string>> _codecFormats = new(StringComparer.OrdinalIgnoreCase)
        {
            ["HAP"] = new List<string> { "HAP", "HAPQ" },
            ["x264"] = new List<string> { "Default" },
            ["x265"] = new List<string> { "Default" }
        };

        private readonly Dictionary<string, List<string>> _codecContainers = new(StringComparer.OrdinalIgnoreCase)
        {
            ["HAP"] = new List<string> { "mov" },
            ["x264"] = new List<string> { "mp4", "mkv", "mov" },
            ["x265"] = new List<string> { "mp4", "mkv", "mov" }
        };

        public FormMain()
        {
            InitializeComponent();
            _ffmpegRunner = new FFmpegRunner();
            _ffmpegRunner.OutputReceived += line => AppendLog(line);
            _ffmpegRunner.ErrorReceived += line => AppendLog("[ERR] " + line);
            _ffmpegRunner.ProcessExited += code => AppendLog($"Process exited with code {code}");

            btn_InputISFolderPicker.Click += Btn_ISFolderPicker_Click;
            btn_OutputVideoFolderPicker.Click += Btn_VideoOutputFolderPicker_Click;

            // Wire handlers then populate codec/container UI so the SelectedIndex change is handled
            try
            {
                cb_ISCodec.SelectedIndexChanged += Cb_ISCodec_SelectedIndexChanged;
                cb_ISFormat.SelectedIndexChanged += Cb_ISFormat_SelectedIndexChanged;
                cb_ISContainer.SelectedIndexChanged += (s, e) => { /* placeholder if needed */ };

                PopulateCodecOptions();
            }
            catch (Exception ex)
            {
                AppendLog("[ERR] Failed to initialize codec UI: " + ex.Message);
            }

            // Start button should be disabled until inputs are valid
            button_ISStart.Enabled = false;

            // Wire input change events to update Start button state
            tb_InputISPath.TextChanged += (s, e) => UpdateStartButtonState();
            tb_OutputVideoPath.TextChanged += (s, e) => UpdateStartButtonState();
            tb_Framerate.TextChanged += (s, e) => UpdateStartButtonState();
            cb_ISCodec.SelectedIndexChanged += (s, e) => UpdateStartButtonState();
            cb_ISContainer.SelectedIndexChanged += (s, e) => UpdateStartButtonState();
            cb_ISFormat.SelectedIndexChanged += (s, e) => UpdateStartButtonState();

            button_ISStart.Click += button_ISStart_Click;
        }

        private void PopulateCodecOptions()
        {
            cb_ISCodec.Items.Clear();
            foreach (var codec in _codecFormats.Keys)
            {
                cb_ISCodec.Items.Add(codec);
            }
            if (cb_ISCodec.Items.Count > 0)
                cb_ISCodec.SelectedIndex = 0;
        }

        private void Cb_ISCodec_SelectedIndexChanged(object? sender, EventArgs e)
        {
            var codec = cb_ISCodec.SelectedItem?.ToString() ?? string.Empty;
            // Populate formats
            cb_ISFormat.Items.Clear();
            if (_codecFormats.TryGetValue(codec, out var formats))
            {
                foreach (var f in formats) cb_ISFormat.Items.Add(f);
            }
            else
            {
                cb_ISFormat.Items.Add("Default");
            }
            if (cb_ISFormat.Items.Count > 0) cb_ISFormat.SelectedIndex = 0;

            // Populate containers
            cb_ISContainer.Items.Clear();
            if (_codecContainers.TryGetValue(codec, out var containers))
            {
                foreach (var c in containers) cb_ISContainer.Items.Add(c);
            }
            else
            {
                cb_ISContainer.Items.Add("mp4");
            }
            if (cb_ISContainer.Items.Count > 0) cb_ISContainer.SelectedIndex = 0;
        }

        private void Cb_ISFormat_SelectedIndexChanged(object? sender, EventArgs e)
        {
            // Placeholder for formats affecting other options in future
        }

        private void UpdateStartButtonState()
        {
            bool hasInputPattern = !string.IsNullOrWhiteSpace(tb_InputISPath.Text);
            bool hasOutputPath = !string.IsNullOrWhiteSpace(tb_OutputVideoPath.Text);
            bool fpsValid = int.TryParse(tb_Framerate.Text, out var fps) && fps > 0;
            bool codecSelected = cb_ISCodec.SelectedItem != null;
            bool containerSelected = cb_ISContainer.SelectedItem != null;

            button_ISStart.Enabled = hasInputPattern && hasOutputPath && fpsValid && codecSelected && containerSelected;
        }

        private void button_ISStart_Click(object? sender, EventArgs e)
        {
            try
            {
                var args = BuildFfmpegArguments();
                AppendLog("ffmpeg " + args);
                _ffmpegRunner?.Start(args);
            }
            catch (Exception ex)
            {
                AppendLog("[ERR] Failed to start ffmpeg: " + ex.Message);
            }
        }

        private string BuildFfmpegArguments()
        {
            // framerate
            var fps = int.TryParse(tb_Framerate.Text, out var f) && f > 0 ? f : 24;

            var parts = new List<string>();
            parts.Add("-y");
            parts.Add($"-framerate {fps}");

            // start number if known
            if (_inputStartIndex.HasValue)
            {
                parts.Add($"-start_number {_inputStartIndex.Value}");
            }

            var inputPattern = tb_InputISPath.Text.Trim();
            parts.Add($"-i \"{inputPattern}\"");

            var codec = cb_ISCodec.SelectedItem?.ToString() ?? "x264";
            var format = cb_ISFormat.SelectedItem?.ToString() ?? string.Empty;

            if (string.Equals(codec, "x264", StringComparison.OrdinalIgnoreCase))
            {
                parts.Add("-c:v libx264");
            }
            else if (string.Equals(codec, "x265", StringComparison.OrdinalIgnoreCase))
            {
                parts.Add("-c:v libx265");
            }
            else if (string.Equals(codec, "HAP", StringComparison.OrdinalIgnoreCase))
            {
                parts.Add("-c:v hap");
                if (string.Equals(format, "HAPQ", StringComparison.OrdinalIgnoreCase))
                    parts.Add("-format hap_q");
                else
                    parts.Add("-format hap");
            }

            var outputPath = tb_OutputVideoPath.Text.Trim();
            parts.Add($"\"{outputPath}\"");

            return string.Join(' ', parts);
        }

        private void Btn_ISFolderPicker_Click(object? sender, EventArgs e)
        {
            using FolderBrowserDialog fbd = new();
            fbd.Description = "Select the folder containing image sequence files";
            fbd.UseDescriptionForTitle = true;
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                PullInputFileInfo(fbd.SelectedPath);
            }
        }

        private void Btn_VideoOutputFolderPicker_Click(object? sender, EventArgs e)
        {
            using SaveFileDialog sfd = new();
            sfd.Title = "Select output video file path";
            var container = cb_ISContainer.SelectedItem?.ToString() ?? "mp4";
            var ext = container.TrimStart('.');
            sfd.Filter = $"{container.ToUpper()} (*.{ext})|*.{ext}|All Files|*.*";
            sfd.DefaultExt = ext;
            sfd.FileName = $"output.{ext}";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                tb_OutputVideoPath.Text = sfd.FileName;
            }
        }

        private void PullInputFileInfo(string folderPath)
        {
            if (!Directory.Exists(folderPath))
            {
                AppendLog("[ERR] Input folder does not exist.");
                return;
            }

            var files = Directory.GetFiles(folderPath)
                                 .Where(f => allowedExtensions.Contains(Path.GetExtension(f).ToLowerInvariant()))
                                 .Select(f => new
                                 {
                                     FullPath = f,
                                     FileName = Path.GetFileNameWithoutExtension(f),
                                     Extension = Path.GetExtension(f).ToLowerInvariant()
                                 })
                                 .ToList();

            if (files.Count == 0)
            {
                AppendLog("[ERR] No image files found in the specified folder.");
                PromptManualPattern(folderPath, null);
                return;
            }

            // Extract numeric suffix and prefix for each file
            var parsed = files.Select(x =>
            {
                var digits = new string(x.FileName.Reverse().TakeWhile(char.IsDigit).Reverse().ToArray());
                var prefix = digits.Length > 0 ? x.FileName[..^digits.Length] : x.FileName;
                int? index = null;
                if (digits.Length > 0 && int.TryParse(digits, out var idx)) index = idx;
                return new { x.FullPath, x.FileName, x.Extension, Digits = digits, Prefix = prefix, Index = index, DigitCount = digits.Length };
            }).ToList();

            // Keep only files that have a numeric suffix
            var withDigits = parsed.Where(p => p.DigitCount > 0).ToList();
            if (withDigits.Count == 0)
            {
                AppendLog("[ERR] No filenames with trailing digits found. Ensure your sequence files end with a numeric index (e.g. img_0001.png).");
                PromptManualPattern(folderPath, null);
                return;
            }

            // Ensure consistent extension, prefix and digit count
            var first = withDigits.First();
            if (withDigits.Any(w => w.Extension != first.Extension))
            {
                AppendLog("[ERR] Mixed file extensions found. Ensure all sequence files share the same extension.");
                PromptManualPattern(folderPath, Path.Combine(folderPath, $"{first.Prefix}%0{first.DigitCount}d{first.Extension}"));
                return;
            }

            if (withDigits.Any(w => w.Prefix != first.Prefix))
            {
                AppendLog("[ERR] Inconsistent filename prefixes detected. Ensure files in the sequence share the same prefix.");
                PromptManualPattern(folderPath, Path.Combine(folderPath, $"{first.Prefix}%0{first.DigitCount}d{first.Extension}"));
                return;
            }

            if (withDigits.Any(w => w.DigitCount != first.DigitCount))
            {
                AppendLog("[ERR] Inconsistent digit counts detected. All files must have the same number of digits in their numeric suffix.");
                PromptManualPattern(folderPath, Path.Combine(folderPath, $"{first.Prefix}%0{first.DigitCount}d{first.Extension}"));
                return;
            }

            // Order numerically by the parsed index
            var ordered = withDigits.OrderBy(w => w.Index).ToList();
            int startIndex = ordered.First().Index!.Value;
            int endIndex = ordered.Last().Index!.Value;
            int expectedCount = endIndex - startIndex + 1;
            if (expectedCount != ordered.Count)
            {
                AppendLog($"[WARN] Sequence has missing frames. Expected {expectedCount} files between {startIndex} and {endIndex} but found {ordered.Count}.");
            }

            AppendLog($"Found {ordered.Count} image files in the input folder. Range: {startIndex}..{endIndex} (digits: {first.DigitCount})");

            _inputStartIndex = startIndex;
            tb_InputISPath.Text = Path.Combine(folderPath, $"{first.Prefix}%0{first.DigitCount}d{first.Extension}");
        }

        private void AppendLog(string text)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new Action<string>(AppendLog), text);
                return;
            }

            rtb_Log.AppendText(text + Environment.NewLine);
            rtb_Log.ScrollToCaret();
        }

        private void PromptManualPattern(string folderPath, string? suggestion)
        {
            var result = MessageBox.Show(
                "An anomaly was detected in the selected folder. Automatic sequence detection failed. Would you like to enter the input file pattern manually?",
                "Sequence detection failed",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Clear any previously detected start index when the user will enter pattern manually
                _inputStartIndex = null;
                if (!string.IsNullOrEmpty(suggestion))
                {
                    tb_InputISPath.Text = suggestion;
                }
                else
                {
                    // Provide a helpful example
                    tb_InputISPath.Text = Path.Combine(folderPath, "%04d.tga");
                }
                tb_InputISPath.Focus();
                tb_InputISPath.SelectionStart = 0;
                tb_InputISPath.SelectionLength = tb_InputISPath.Text.Length;
            }
            else
            {
                AppendLog("User declined to enter manual pattern.");
            }
        }
    }
}
