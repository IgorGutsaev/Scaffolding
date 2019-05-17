using Scaffolding.Common.Helpers;
using Scaffolding.TaskManager.Abstractions.Models;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Scaffolding.TaskManager.Abstractions
{
    public class Scheduler
    {
        private event EventHandler<Job> OnNewJob;

        public Scheduler(Action<SchedulerSettings> setupAction
            , Predicate<Job> isNewJob)
        {
            _settings = setupAction?.CreateTargetAndInvoke();
            _settings.OnNewJob += OnNewJob;
            _isNewJob = isNewJob ?? new Predicate<Job>((j) => true);

            _timer = new Timer(new TimerCallback(ProduceJob), _settings.Tasks
                , _settings?.DueTime ?? new TimeSpan(0, (int)SchedulerSettings.DefaultDueTime, 0)
                , _settings?.Period ?? new TimeSpan(0, (int)SchedulerSettings.DefaultPeriod, 0));
        }

        private void ProduceJob(object obj)
        {
            IEnumerable<Task> tasks = (IEnumerable<Task>)obj;

            ConcurrentBag<Job> jobList = new ConcurrentBag<Job>();
            List<System.Threading.Tasks.Task> jobAddTasks = new List<System.Threading.Tasks.Task>();
            Parallel.ForEach(tasks, (t) =>
            {
                jobAddTasks.Add(System.Threading.Tasks.Task.Run(
                    () => { t.BuildJobList().ToList().ForEach(j => jobList.Add(j)); })); 
            });

            System.Threading.Tasks.Task.WaitAll(jobAddTasks.ToArray());

            jobList.ToList().Where(j => _isNewJob(j)).ToList()
                .ForEach(j => OnNewJob?.Invoke(this, j));
        }

        private readonly SchedulerSettings _settings;
        private readonly Predicate<Job> _isNewJob;
        private readonly Timer _timer;
    }
}
