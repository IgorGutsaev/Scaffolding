using Scaffolding.Scheduler.Abstractions.Models;
using System;
using System.Collections.Generic;

namespace Scaffolding.Scheduler.Abstractions
{
    public abstract class Task : ISchedulerObject
    {
        /// <summary>
        /// Unique task identifier
        /// </summary>
        public string Identifier { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        /// <summary>
        /// Notification settings
        /// </summary>
        public string Notification { get; private set; }
        /// <summary>
        /// Run configuration
        /// </summary>
        public string Schedule { get; private set; }
        public TimeSpan Horizon { get; private set; } // Plan task til Now + Horizon
        /// <summary>
        /// Task input
        /// </summary>
        public string Arguments { get; private set; }

        public string Agents { get; private set; }

        public bool Active { get; private set; }
        public TimeSpan Timeout { get; private set; }
    }
}
