using Scaffolding.Scheduler.Abstractions.Models;
using System;

namespace Scaffolding.Scheduler.Abstractions
{
    public class Job : ISchedulerObject
    {
        public string Uid { get; private set; }
        public string Identifier { get; private set; }
        /// <summary>
        /// Utc
        /// </summary>
        public DateTime NotBefore { get; private set; }
        /// <summary>
        /// Utc
        /// </summary>
        public DateTime? NotAfter { get; private set; }
        public string Agent { get; private set; }
        /// <summary>
        /// Utc
        /// </summary>
        public DateTime? Start { get; private set; }
        /// <summary>
        /// Utc
        /// </summary>
        public DateTime? Finish { get; private set; }
        /// <summary>
        /// Utc
        /// </summary>
        public DateTime? LastActivity { get; private set; }
        public string Log { get; private set; }
        /// <summary>
        /// Utc
        /// </summary>
        public DateTime Date { get; private set; }
        public string Result { get; private set; }
        
        public JobState State { get; private set; }

        public static Job Create(string identifier, DateTime notBefore, string agent, DateTime? notAfter)
        {
            if (string.IsNullOrWhiteSpace(identifier))
                throw new Exception("Identifier must be specified");

            return new Job
            {
                Identifier = identifier.Trim(),
                NotBefore = notBefore,
                Agent = agent ?? string.Empty,
                NotAfter = notAfter
            };
        }
    }
}
