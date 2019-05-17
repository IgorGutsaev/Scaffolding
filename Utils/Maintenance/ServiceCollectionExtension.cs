using Microsoft.Extensions.DependencyInjection;
using Scaffolding.Common.Helpers;
using Scaffolding.Utils.Abstractions.Maintenance;
using System;
using System.Collections.Generic;
using System.Text;

namespace Scaffolding.Utils.Maintenance
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddMaintenance(this IServiceCollection serviceCollection, Action<MaintenanceService> setupAction = null)
        {
            serviceCollection.AddSingleton<IMaintenanceService>(sp => { return setupAction?.CreateTargetAndInvoke(); });

            return serviceCollection;
        }
    }
}
