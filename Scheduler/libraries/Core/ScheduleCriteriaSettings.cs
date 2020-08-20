using Newtonsoft.Json;
using Scaffolding.Scheduler.Core.Enums;
using System;

namespace Scaffolding.Scheduler.Core
{

    public class ScheduleCriteriaSettings
    {
        [JsonProperty(PropertyName = "day", Order = 1)]
        public ScheduleCriteriaSettings<DayMode> Day { get; set; }
        [JsonProperty(PropertyName = "time", Order = 2)]
        public ScheduleCriteriaSettings<TimeMode> Time { get; set; }

        public ScheduleCriteriaSettings Initialize(string data)
        {
            if (string.IsNullOrWhiteSpace(data))
                throw new ArgumentException("Invalid schedule");

            ScheduleCriteriaSettings des = JsonConvert.DeserializeObject<ScheduleCriteriaSettings>(data);

            Day = des.Day;
            Time = des.Time;

            return this;
        }
    }

    public class ScheduleCriteriaSettings<T> where T : Enum
    {
        [JsonProperty(PropertyName = "mode", Order = 1)]
        public T Mode { get; set; }

        [JsonProperty(PropertyName = "args", Order = 2)]
        public object Arguments { get; set; }
    }
}
