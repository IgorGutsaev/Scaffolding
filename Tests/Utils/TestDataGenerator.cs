using Scaffolding.Utils.Abstractions.Maintenance;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Scaffolding.Tests.Utils
{
    public class TestDataGenerator
    {
        static public IEnumerable<dynamic> GetMaintenanceProcesses()
        {
            yield return new
            {
                Tasks = new dynamic[] {
                new { Name = "Task 1", Type = MaintenanceTaskType.DiskCleaner, Conditions = new[] { new { }, new { } }, Actions = new[] { new { }, new { } } },
                new { Name = "Task 1", Type = MaintenanceTaskType.Archiver, Conditions = new[] { new { }, new { } }, Actions = new[] { new { }, new { } } }
                }
            };
        }
    }
}
