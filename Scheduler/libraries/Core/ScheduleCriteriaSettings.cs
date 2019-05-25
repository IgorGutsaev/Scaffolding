using Newtonsoft.Json;
using Scaffolding.Scheduler.Core.Enums;
using System;

namespace Scaffolding.Scheduler.Core
{

    public class ScheduleCriteriaSettings
    {
        [JsonProperty(PropertyName = "day", Order = 1)]
        public ScheduleCriteriaSettings<DayMode> Day { get; set; }
        [JsonProperty(PropertyName = "time", Order = 1)]
        public ScheduleCriteriaSettings<TimeMode> Time { get; set; }
    }

    public class ScheduleCriteriaSettings<T> where T : Enum
    {
        [JsonProperty(PropertyName = "mode", Order = 1)]
        public T Mode { get; set; }

        [JsonProperty(PropertyName = "args", Order = 2)]
        public object Arguments { get; set; }
    }
}
