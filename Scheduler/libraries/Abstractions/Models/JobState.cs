using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Scaffolding.Scheduler.Abstractions
{
    public enum JobState
    {
        [Description("created")]
        Created,
        [Description("inprogress")]
        InProgress,
        /// <summary>
        /// Done successfully
        /// </summary>
        [Description("done")]
        Done,
        /// <summary>
        /// Failed
        /// </summary>
        [Description("failed")]
        Failed,
        /// <summary>
        /// Closed manually
        /// </summary>
        [Description("closed")]
        Closed
    }
}
