using System;
using System.Collections.Generic;
using System.Text;

namespace Scaffolding.TaskManager.Abstractions.Models
{
    public class SchedulerSettings
    {
        public TimeSpan DueTime { get; set; }
        public TimeSpan Period { get; set; }

        public IEnumerable<Task> Tasks { get; set; }

        public event EventHandler<Job> OnNewJob;


        public const uint DefaultDueTime = 0;
        public const uint DefaultPeriod = 5;
    }
}
