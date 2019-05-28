using Newtonsoft.Json;
using Scaffolding.Scheduler.Abstractions;
using Scaffolding.Scheduler.Core;
using System;
using System.Diagnostics;
using System.Linq;
using Xunit;

namespace Scaffolding.Tests.Scheduler
{
    public class SchedulerTest
    {
        [Theory]
        //[InlineData("report", "{\"day\": { \"mode\": 1, \"args\": \"\" },\"time\": { \"mode\": 1, \"args\": {\"Item1\":\"09:00:00\",\"Item2\":\"00:45:00\"} }}", "", 24)]
        [InlineData("z-report", "{\"day\":{\"mode\":1,\"args\":\"\"},\"time\":{\"mode\":2,\"args\":[\"01:00:00\",\"03:00:00\",\"08:00:00\"]}}", "", 24)]
        public void Test_Scheduler_Build(string identifier, string schedule, string agents, double horizonHours)
        {
            //ScheduleCriteriaSettings sh = new ScheduleCriteriaSettings
            //{
            //    Day = new ScheduleCriteriaSettings<Scaffolding.Scheduler.Core.Enums.DayMode> { Mode = Scaffolding.Scheduler.Core.Enums.DayMode.Daily, Arguments = "" },
            //    Time = new ScheduleCriteriaSettings<Scaffolding.Scheduler.Core.Enums.TimeMode>
            //    {
            //        Mode = Scaffolding.Scheduler.Core.Enums.TimeMode.ExactTime,
            //        Arguments = JsonConvert.SerializeObject(new TimeSpan[] { new TimeSpan(1, 0, 0), new TimeSpan(3, 0, 0), new TimeSpan(8, 0, 0) })
            //    }
            //};

            //string d= JsonConvert.SerializeObject(sh);
            

            // Prepare
            Scaffolding.Scheduler.Core.Scheduler scheduler =
                new Scaffolding.Scheduler.Core.Scheduler((settings) =>
                {
                    settings.DelayStart = new TimeSpan(0, 0, 5);
                    settings.Period = new TimeSpan(0, 5, 0);
                    settings.Tasks = () => (new Scaffolding.Scheduler.Abstractions.Task[]
                    {
                        Task.Create(identifier, schedule, string.Empty, agents, TimeSpan.FromHours(horizonHours))
                    }).ToList();
                }, (job) => true);

            scheduler.OnNewJob += (sender, j) => {
                Debug.Write(j.ToString());
            };
            // Pre-validate

            // Perform
            scheduler.ProduceJob();

            // Post-validate
        }
    }
}
