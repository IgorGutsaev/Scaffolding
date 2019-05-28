using Scaffolding.Scheduler.Abstractions.Models;
using System;

namespace Scaffolding.Scheduler.Abstractions
{
    public class Task : ISchedulerObject
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

        static public Task Create(string identifier, string schedule, string args, string agents, TimeSpan horizon, string description = "")
            => new Task
            {
                Active = true,
                Identifier = identifier,
                Arguments = args,
                Agents = agents,
                Description = description,
                Horizon = horizon == TimeSpan.Zero ? TimeSpan.FromHours(1) : horizon,
                Notification = "",
                Schedule = schedule,
                Timeout = TimeSpan.FromMinutes(1),
                Title = ""
            };
    }
}
