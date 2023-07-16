using System;
using System.Diagnostics;
using System.Threading;

namespace WsaInstaller.Utils
{
    internal class PowerShellExecutor
    {
        public event EventHandler<string> CommandCompleted;
        public event EventHandler<string> CommandFailed;

        public void ExecuteCommand(string command)
        {
            Thread thread = new Thread(() =>
            {
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "powershell.exe";
                startInfo.Arguments = command;
                startInfo.RedirectStandardOutput = true;
                startInfo.RedirectStandardError = true;
                startInfo.UseShellExecute = false;
                startInfo.CreateNoWindow = true;
                startInfo.Verb = "runas";

                process.StartInfo = startInfo;
                process.OutputDataReceived += Process_OutputDataReceived;
                process.ErrorDataReceived += Process_ErrorDataReceived;
                process.EnableRaisingEvents = true;

                try
                {
                    process.Start(); ;
                    process.BeginOutputReadLine();
                    process.BeginErrorReadLine();
                    process.WaitForExit();
                }
                catch (Exception ex)
                {
                    CommandFailed?.Invoke(this, ex.Message);
                }
            });
            thread.Start();
        }

        private void Process_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            CommandCompleted?.Invoke(this, e.Data);
        }

        private void Process_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(e.Data))
            {
                CommandFailed?.Invoke(this, e.Data);
            }
        }
    }
}
