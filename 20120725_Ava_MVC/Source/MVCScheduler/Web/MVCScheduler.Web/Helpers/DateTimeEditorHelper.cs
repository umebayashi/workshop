using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCScheduler.Web.Helpers
{
	public static class DateTimeEditorHelper
	{
		public static IEnumerable<SelectListItem> GetTimeOfDays(bool addEmptyOption = true)
		{
			var list = new List<SelectListItem>();

			if (addEmptyOption)
			{
				list.Add(new SelectListItem());
			}

			for (int h = 0; h <= 23; h++)
			{
				foreach (var m in new int[] { 0, 30 })
				{
					var value = string.Format("{0}:{1}", h.ToString("00"), m.ToString("00"));
					list.Add(new SelectListItem
					{
						Text = value,
						Value = value
					});
				}
			}

			return list;
		}
	}
}