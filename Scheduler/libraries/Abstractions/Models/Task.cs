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
        public string Identifier { get; protected set; }
        public string Title { get; protected set; }
        public string Description { get; protected set; }
        /// <summary>
        /// Notification settings
        /// </summary>
        public string Notification { get; protected set; }
        /// <summary>
        /// Run configuration
        /// </summary>
        public string Schedule { get; protected set; }
        public TimeSpan Horizon { get; protected set; } // Plan task til Now + Horizon
        /// <summary>
        /// Task input
        /// </summary>
        public string Arguments { get; protected set; }

        public string Agents { get; protected set; }

        public bool Active { get; protected set; }
        public TimeSpan Timeout { get; protected set; }
    }
}
