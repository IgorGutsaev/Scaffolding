using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Scaffolding.Scheduler.Abstractions
{
    public enum JobState
    {
        [Description("Created")]
        Created,
        [Description("InProgress")]
        InProgress,
        /// <summary>
        /// Done successfully
        /// </summary>
        [Description("Done")]
        Done,
        /// <summary>
        /// Failed
        /// </summary>
        [Description("Failed")]
        Failed,
        /// <summary>
        /// Closed manually
        /// </summary>
        [Description("Closed")]
        Closed
    }
}
