using System;
using System.Collections.Generic;
using System.Text;

namespace Scaffolding.Utils.Abstractions.Maintenance
{
    public interface IMaintenanceService
    {
        IMaintenanceProcess AddProcess(string name = "");
    }
}
