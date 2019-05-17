using Scaffolding.Utils.Abstractions.Maintenance;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Scaffolding.Utils.Maintenance
{
    public class MaintenancePipeline : IMaintenanceProcess
    {
        public string Name => throw new NotImplementedException();
    }

    public static class MaintenancePipelineHelper
    {

        public static Func<T, Tres> Add<T, Tres>( this MaintenancePipeline pipeline, Func<T, Tres> action)
            => action;

        public static Func<T1, Tres> Add<T, T1, Tres>(this Func<T, T1> input, Func<T1, Tres> action)
            => action;

        public static Action<T1> Add<T, T1>(this Func<T, T1>  input, Action<T1> action)
            => action;
    }
}
