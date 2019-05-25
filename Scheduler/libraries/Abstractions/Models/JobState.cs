using System;
using System.Collections.Generic;
using System.Text;

namespace Scaffolding.Scheduler.Abstractions
{
    public enum JobState
    {
        Created,
        InProgress,
        /// <summary>
        /// Done successfully
        /// </summary>
        Done,
        /// <summary>
        /// Failed
        /// </summary>
        Failed,
        /// <summary>
        /// Closed manually
        /// </summary>
        Closed
    }
}
