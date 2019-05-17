using System;
using Xunit;
using Scaffolding.Utils.Maintenance;
using Microsoft.Extensions.DependencyInjection;
using Scaffolding.Tests.Utils;
using System.Diagnostics;

namespace Scaffolding.Test.Utils
{
    public class MaintenanceTest
    {

        public MaintenanceTest()
        {
            MaintenancePipeline mp = new MaintenancePipeline();

            mp.Add((int a) => { return 0.0; })
                .Add(V1);
        }

        private double V(int y) { Debug.WriteLine("231312312312312"); return 0; }

        private void V1(double y) { Debug.WriteLine("231312312312312999999"); }

        [Fact]
      //  [Theory]
     //   [MemberData(nameof(TestDataGenerator.GetMaintenanceProcesses), MemberType = typeof(TestDataGenerator))]
        public void Test_instantiate_Maintenance_service()//dynamic[] processes)
        {
            // Perform
            //IServiceProvider provider = new ServiceCollection()
            //   .AddMaintenance((s) => {
            //       s.AddProcess();
            //   }).BuildServiceProvider();

            // Validate
        }
    }
}
