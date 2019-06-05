using ExtensibleDiagnosticIntefaces;
using ExtensibleDiagnosticIntefaces.Events;
using System;
using System.Composition;
using System.Threading;

namespace NetworkingDiagnotic
{

    [Export(typeof(IDiagnositicRunner))]
    public class NetworkingDiagnosticRunner : IDiagnositicRunner
    {
        public event EventHandler<LogMessageArgs> LogMessage;

        public void Run()
        {
            System.Diagnostics.Process proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = "ping.exe";
            proc.StartInfo.Arguments = "192.168.1.18";
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.Start();


            Thread.Sleep(10000);
            //LogMessage.Invoke(this, new LogMessageArgs() { Message = results, DebugLevel = 1 });
        }
    }
}
