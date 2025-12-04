using System;
using System.Diagnostics;

class FFmpegRunner
{
    private Process? _proc;

    public void Start()
    {
        var psi = new ProcessStartInfo
        {
            FileName = @"C:\Program Files\ffmpeg\bin\ffmpeg.exe",
            Arguments = "-version",
            UseShellExecute = false,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            RedirectStandardInput = true,
            CreateNoWindow = true
        };

        _proc = new Process
        {
            StartInfo = psi,
            EnableRaisingEvents = true
        };

        _proc.OutputDataReceived += (sender, e) =>
        {
            if (e.Data != null)
            {
                System.Diagnostics.Debug.WriteLine("OUT: " + e.Data);
            }
        };

        _proc.ErrorDataReceived += (sender, e) =>
        {
            if (e.Data != null)
            {
                System.Diagnostics.Debug.WriteLine("ERR: " + e.Data);
            }
        };

        _proc.Exited += (sender, e) =>
        {
            var proc = (Process)sender;
            System.Diagnostics.Debug.WriteLine("Process finished with code " + proc.ExitCode);
            proc.Dispose();
        };

        _proc.Start();
        _proc.BeginOutputReadLine();
        _proc.BeginErrorReadLine();
    }

    public void SendInput(string line)
    {
        if (_proc == null || _proc.HasExited) return;

        _proc.StandardInput.WriteLine(line);
        _proc.StandardInput.Flush();
    }

    public void Stop()
    {
        if (_proc == null || _proc.HasExited) return;

        try
        {
            _proc.Kill();
        }
        catch { }
    }
}
