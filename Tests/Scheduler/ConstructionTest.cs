using Scaffolding.Scheduler.Abstractions;
using System;
using System.Linq;
using Xunit;

namespace Scaffolding.Tests.Scheduler
{
    public class SchedulerTest
    {
        [Theory]
        [InlineData("report", "{\"day\": { \"mode\": 1, \"args\": \"\" },\"time\": { \"mode\": 1, \"args\": {\"Item1\":\"09:00:00\",\"Item2\":\"00:45:00\"} }}", "", 24)]
        public void Test_Scheduler_Build(string identifier, string schedule, string agents, double horizonHours)
        {
            // Prepare
            Scaffolding.Scheduler.Core.Scheduler scheduler =
                new Scaffolding.Scheduler.Core.Scheduler((settings) =>
                {
                    settings.DelayStart = new TimeSpan(0, 0, 5);
                    settings.Period = new TimeSpan(0, 5, 0);
                    settings.Tasks = // DataProvider.GetTasks
                    (new Scaffolding.Scheduler.Abstractions.Task[]
                    {
                        Task.Create(identifier, schedule, string.Empty, agents, TimeSpan.FromHours(horizonHours))
                    }).ToList();
                }, (job) => true);
            
            // Pre-validate

            // Perform
            scheduler.ProduceJob();

            // Post-validate
        }
    }
}
