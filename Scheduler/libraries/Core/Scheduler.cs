using Newtonsoft.Json;
using Scaffolding.Common.Helpers;
using Scaffolding.Scheduler.Abstractions;
using Scaffolding.Scheduler.Abstractions.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Threading = System.Threading.Tasks;

namespace Scaffolding.Scheduler.Core
{
    public class Scheduler
    {
        public event EventHandler<Job> OnNewJob;

        public Scheduler(Action<SchedulerSettings> setupAction
            , Predicate<Job> isNewJob)
        {
            Settings = setupAction?.CreateTargetAndInvoke();
            Settings.OnNewJob += OnNewJob;
            _isNewJob = isNewJob ?? new Predicate<Job>((j) => true);
        }

        public async void ProduceJob()
        => await Threading.Task.Factory.StartNew(() => 
        {
            ConcurrentBag<Job> jobList = new ConcurrentBag<Job>();
            List<Threading.Task> jobAddTasks = new List<Threading.Task>();

            System.Threading.Tasks.Parallel.ForEach(Settings.Tasks().Where(t => t.Active), (t) =>
            {
                jobAddTasks.Add(System.Threading.Tasks.Task.Run(
                    () => {
                        Schedule s = new Schedule((x) => x.Initialize(t.Schedule)
                            , (d) => (d.DayOfWeek != DayOfWeek.Saturday && d.DayOfWeek != DayOfWeek.Sunday));

                        IEnumerable<DateTime> points = s.Resolve(DateTime.UtcNow, DateTime.UtcNow.Add(t.Horizon));

                        foreach (var point in points)
                        {
                            string[] agents = t.Agents.Split(new char[] { ';', ',' }, StringSplitOptions.RemoveEmptyEntries);
                            if (agents.Length == 0) // Anyone can execute task if no agent value
                                agents = new string[] { string.Empty };

                            foreach (var agent in agents)
                                jobList.Add(Job.Create(t.Identifier, point, agent.Trim(), t.Arguments.Trim(), point.Add(t.Timeout)));
                        }
                    }));
            });

            System.Threading.Tasks.Task.WaitAll(jobAddTasks.ToArray());

            jobList.ToList().Where(j => _isNewJob(j)).ToList()
                .ForEach(j => OnNewJob?.Invoke(this, j));
        });

        private readonly Predicate<Job> _isNewJob;
        private Timer _timer;

        public SchedulerSettings Settings { get; }
    }
}
