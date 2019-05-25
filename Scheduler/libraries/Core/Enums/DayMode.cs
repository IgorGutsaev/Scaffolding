using System;
using System.Collections.Generic;
using System.Text;

namespace Scaffolding.Scheduler.Core.Enums
{
    public enum DayMode
    {
        None = 0x00,
        Daily = 0x01,
        Weekly,
        Monthly,
        WorkDays,
        Weekend,
        FirstMonthDay,
        LastMonthDay,
        FirstMonthWorkDay,
        LastMonthWorkDay,
        ExactDayOfWeek,
        ExactDayOfMonth, // Day N of month
    }
}
