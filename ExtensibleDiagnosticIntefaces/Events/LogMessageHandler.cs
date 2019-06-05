using System;
namespace ExtensibleDiagnosticIntefaces.Events
{
    public class LogMessageArgs : EventArgs
    {
        public string Message { get; set; }
        public int DebugLevel { get; set; }
    }
}
