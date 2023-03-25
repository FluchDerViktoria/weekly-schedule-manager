using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluchDerVika.WeeklySchedule.Client.Extention
{
  public static class DateTimeExtention
  {
    /// <summary>
    /// Calculates and returns start of week.
    /// </summary>
    /// <param name="datetime"></param>
    /// <param name="firstDayOfWeek"></param>
    /// <returns></returns>
    public static DateTime GetStartOfWeek(this DateTime datetime, DayOfWeek firstDayOfWeek = DayOfWeek.Monday)
    {
      int offset = (int)firstDayOfWeek - (int)datetime.DayOfWeek;

      if (offset > 0)
        offset -= 7;

      return datetime.AddDays(offset).StripTime();
    }
    
    /// <summary>
    /// Sets time of a given date to 00:00:00 and returns new DateTime-Object
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns></returns>
    public static DateTime StripTime(this DateTime dateTime)
    {
      return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, 0, 0, 0, dateTime.Kind);
    }

    /// <summary>
    /// Redirect to <see cref="ISOWeek.GetWeekOfYear(DateTime)"/>
    /// </summary>
    /// <param name="dateTime"></param>
    /// <returns></returns>
    public static int GetISOCalendarWeek(this DateTime dateTime)
    {
      return ISOWeek.GetWeekOfYear(dateTime);
    }
  }
}
