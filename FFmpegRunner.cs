using System;
using System.Diagnostics;

class FFmpegRunner
{
    private Process? _proc;

    public event Action<string>? OutputReceived;
    public event Action<string>? ErrorReceived;
    public event Action<int>? ProcessExited;

    public void Start(string command)
    {
        var psi = new ProcessStartInfo
        {
            FileName = @"C:\Program Files\ffmpeg\bin\ffmpeg.exe", // Hardcoded path to ffmpeg executable for testing
            Arguments = command,
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
                Debug.WriteLine("OUT: " + e.Data);
                OutputReceived?.Invoke(e.Data);
            }
        };

        _proc.ErrorDataReceived += (sender, e) =>
        {
            if (e.Data != null)
            {
                Debug.WriteLine("ERR: " + e.Data);
                ErrorReceived?.Invoke(e.Data);
            }
        };

        _proc.Exited += (sender, e) =>
        {
            var proc = (Process?)sender;
            if (proc == null)
                return;
            {
                Debug.WriteLine("Process finished with code " + proc.ExitCode);
                ProcessExited?.Invoke(proc.ExitCode);
                proc.Dispose();
                if (ReferenceEquals(_proc, proc))
                    _proc = null;
            }
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
