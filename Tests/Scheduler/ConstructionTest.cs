using Scaffolding.Scheduler.Core;
using System;
using System.Linq;
using System.Threading;
using Xunit;

namespace Scheduler
{
    public class SchedulerTest
    {
        [Theory]
        [MemberData()]
        public void Test_Scheduler_Build()
        {
            // Prepare
            Scaffolding.Scheduler.Core.Scheduler scheduler =
                new Scaffolding.Scheduler.Core.Scheduler((settings) =>
                {
                    settings.DueTime = new TimeSpan(0, 0, 5);
                    settings.Period = new TimeSpan(0, 5, 0);
                    settings.Tasks = // DataProvider.GetTasks
                   (new Scaffolding.Scheduler.Abstractions.Task[0]
                   {
                       Task.
                   }).ToList();
                }, (job) => true);

            // Pre-validate

            // Perform
            scheduler.Start();
            Thread.Sleep(10 * 1000);
            scheduler.Stop();

            // Post-validate
        }
    }
}
