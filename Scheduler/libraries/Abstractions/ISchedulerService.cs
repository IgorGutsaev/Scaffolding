using Scaffolding.Scheduler.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scaffolding.Scheduler.Abstractions
{
    /// <summary>
    /// Scheduler service
    /// </summary>
    public interface ISchedulerService<T> where T : ISchedulerObject
    {
        IEnumerable<T> Get(Predicate<T> predicate);

        T Save(T entity);

        bool Delete(T entity);

        bool Exists(T entity);
    }
}
