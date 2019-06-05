using ExtensibleDiagnosticIntefaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Albero
{
    public class DiagnosticRunner
    {
        IEnumerable<IDiagnositicRunner> Runners;
        public DiagnosticRunner(IEnumerable<IDiagnositicRunner> runners)
        {
            Runners = runners;
            foreach (var runner in Runners)
            {
                runner.LogMessage += Runner_LogMessage;
            }
        }

        private void Runner_LogMessage(object sender, ExtensibleDiagnosticIntefaces.Events.LogMessageArgs e)
        {
            Console.WriteLine(e.Message);
        }

        public void Run()
        {

            foreach (var runner in Runners)
            {
                runner.Run();
            }
        }
    }
}
