using Scaffolding.TaskManager.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scaffolding.TaskManager.Abstractions
{
    public abstract class Task : ITaskManagerObject
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
        public string Scheduler { get; private set; }
        /// <summary>
        /// Task input
        /// </summary>
        public string Arguments { get; private set; }
        public bool Active { get; private set; }
        public TimeSpan Timeout { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public bool Deleted { get; private set; }

        public virtual IEnumerable<Job> BuildJobList()
        {
            throw new Exception();
        }
    }
}
