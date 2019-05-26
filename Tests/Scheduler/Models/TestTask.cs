using Scaffolding.Scheduler.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scaffolding.Tests.Scheduler.Models
{
    public class TestTask : Task
    {
        static public TestTask Create(string identifier, string schedule, string args, string agents, TimeSpan horizon, string description = "")
            => new TestTask
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
