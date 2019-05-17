using Scaffolding.TaskManager.Abstractions.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scaffolding.TaskManager.Abstractions
{
    /// <summary>
    /// Task manager service
    /// </summary>
    public interface ITaskManager<T> where T : ITaskManagerObject
    {
        IEnumerable<T> Get(Predicate<T> predicate);

        T Save(T entity);

        bool Delete(T entity);

        bool Exists(T entity);
    }
}
