using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace MVCScheduler.Web.Models
{
	public class SchedulerDateTime
	{
		public SchedulerDateTime()
		{
			this.DateFormat = DATEFORMAT_DEFAULT;
			this.TimeFormat = TIMEFORMAT_DEFAULT;
		}

		public SchedulerDateTime(DateTime? value)
		{
			this.DateFormat = DATEFORMAT_DEFAULT;
			this.TimeFormat = TIMEFORMAT_DEFAULT;

			if (value.HasValue)
			{
				this.Value = value.Value;
			}
		}

		public const string DATEFORMAT_DEFAULT = "yyyy/MM/dd";

		public const string TIMEFORMAT_DEFAULT = "HH:mm";

		public string Date { get; set; }

		public string Time { get; set; }

		public string DateFormat { get; set; }

		public string TimeFormat { get; set; }

		public DateTime Value
		{
			get
			{
				var dateValue = DateTime.Parse(this.Date);
				var timeValue = TimeSpan.Parse(this.Time);

				return new DateTime(
					dateValue.Year,
					dateValue.Month,
					dateValue.Day,
					timeValue.Hours,
					timeValue.Minutes,
					timeValue.Seconds);
			}
			set
			{
				this.Date = value.ToString(this.DateFormat);
				this.Time = value.ToString(this.TimeFormat);
			}
		}
	}
}