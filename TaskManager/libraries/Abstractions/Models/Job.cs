using Scaffolding.TaskManager.Abstractions.Models;
using System;

namespace Scaffolding.TaskManager.Abstractions
{
    public class Job : ITaskManagerObject
    {
        public string Uid { get; private set; }
        public DateTime NotBefore { get; private set; }
        public DateTime? NotAfter { get; private set; }
        public string Agent { get; private set; }
        public DateTime? Start { get; private set; }
        public DateTime? Finish { get; private set; }
        public DateTime? LastActivity { get; private set; }
        public string Log { get; private set; }

        public DateTime Date { get; private set; }
        public string Result { get; private set; }
        
        public JobState State { get; private set; }
    }
}
