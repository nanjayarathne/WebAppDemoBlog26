using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppDemoBlog26.Common
{
    public class DateRangeAttribute :RangeAttribute
    {
        public DateRangeAttribute(string minimumValue)
           : base(typeof(DateTime), minimumValue, DateTime.Now.ToShortDateString())
        {

        }
    }

    public class DateRangeOneYearBackAttribute : RangeAttribute
    {
        public DateRangeOneYearBackAttribute(string minimumValue)
           : base(typeof(DateTime), minimumValue, DateTime.Now.AddYears(-1).ToShortDateString())
        {

        }
    }
}