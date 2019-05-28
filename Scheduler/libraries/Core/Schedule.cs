using Newtonsoft.Json;
using Scaffolding.Common.Helpers;
using Scaffolding.Scheduler.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Scaffolding.Scheduler.Core
{
    /// <summary>
    /// 
    /// </summary>
    public class Schedule
    {
        private readonly ScheduleCriteriaSettings _settings;
        private readonly Predicate<DateTime> _isWorkDay;

        public Schedule(Action<ScheduleCriteriaSettings> setupAction, Predicate<DateTime> isWorkDay)
        {
            _settings = setupAction?.CreateTargetAndInvoke();
            _isWorkDay = isWorkDay;
        }

        public IEnumerable<DateTime> Resolve(DateTime from, DateTime to)
        {
            var result = new List<DateTime>();

            if (from > to)
                return result;

            DateTime date = from.Date;

            while (date <= to.Date)
            {
                if (IsDateMatch(date))
                    result.AddRange(ResolveForDate(from, to));
            }

            return result;
        }

        private bool IsDateMatch(DateTime date)
        {
            date = date.Date;

            switch (_settings.Day.Mode)
            {
                case DayMode.None:
                    return false;
                case DayMode.Daily:
                    return true;
                case DayMode.Weekly:
                    return date.DayOfWeek == (DayOfWeek)Convert.ToInt32(_settings.Day.Arguments);
                case DayMode.Monthly:
                    return date.Day == Convert.ToInt32(_settings.Day.Arguments);
                case DayMode.WorkDays:
                    return _isWorkDay(date);
                case DayMode.Weekend:
                    return date.DayOfWeek == (DayOfWeek.Saturday | DayOfWeek.Sunday);
                case DayMode.FirstMonthDay:
                    return date.Day == 1;
                case DayMode.LastMonthDay:
                    return date.Day == new DateTime(date.Year, date.Month, 1).AddMonths(1).AddDays(-1).Day;
                case DayMode.FirstMonthWorkDay:
                    {
                        DateTime firstWorkDay = new DateTime(date.Year, date.Month, 1);
                        bool finded = true;
                        while (!_isWorkDay(firstWorkDay) && firstWorkDay.Month == date.Month)
                        {
                            firstWorkDay = firstWorkDay.AddDays(1);
                            if (firstWorkDay.Month > date.Month)
                                finded = false;
                        }
                        if (finded)
                            return date.Day == firstWorkDay.Day;

                        return false;
                    }
                case DayMode.LastMonthWorkDay:
                    {
                        DateTime lastWorkDay = new DateTime(date.Year, date.Month, 1).AddMonths(1).AddDays(-1);
                        bool finded = true;
                        while (!_isWorkDay(lastWorkDay) && lastWorkDay.Month == date.Month)
                        {
                            lastWorkDay = lastWorkDay.AddDays(-1);
                            if (lastWorkDay.Month < date.Month)
                                finded = false;
                        }
                        if (finded)
                            return date.Day == lastWorkDay.Day;

                        return false;
                    }
                case DayMode.ExactDayOfWeek:
                    return ((int[])_settings.Day.Arguments).Contains((int)date.DayOfWeek); // Note! Sunday = 0
                case DayMode.ExactDayOfMonth:
                    return ((int[])_settings.Day.Arguments).Contains(date.Day);
                default:
                    return false;
            }
        }

        private IEnumerable<DateTime> ResolveForDate(DateTime from, DateTime to)
        {
            var result = new List<DateTime>();

            switch (_settings.Time.Mode)
            {
                case TimeMode.None:
                default:
                    break;
                case TimeMode.Periodically:
                    {
                        (TimeSpan startTime, TimeSpan period) args
                            = JsonConvert.DeserializeObject<ValueTuple<TimeSpan, TimeSpan>>(_settings.Time.Arguments.ToString());

                        DateTime next = from.Date.Add(args.startTime);
                        while (next <= to)
                        {
                            result.Add(next);
                            next = next.Add(args.period);
                        }

                        break;
                    }
                case TimeMode.ExactTime:
                    {
                        TimeSpan[] args
                             = JsonConvert.DeserializeObject<TimeSpan[]>(_settings.Time.Arguments.ToString());

                        DateTime startDate = from.Date;
                        while (startDate <= to.Date)
                        {
                            foreach (TimeSpan checkpoint in args)
                                if (startDate.Add(checkpoint) >= from && startDate.Add(checkpoint) <= to)
                                    result.Add(startDate.Add(checkpoint));
                        }

                        break;
                    }
            }

            return result;
        }
    }
}
