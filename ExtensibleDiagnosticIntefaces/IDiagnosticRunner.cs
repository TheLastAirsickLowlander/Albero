using System;
using ExtensibleDiagnosticIntefaces.Events;

namespace ExtensibleDiagnosticIntefaces
{
    public interface IDiagnositicRunner
    {
        event EventHandler<LogMessageArgs> LogMessage;

        void Initialize();
        void Run();
        void Stop();
        void Reset();
        
        String[] GetResults();
    }
}
