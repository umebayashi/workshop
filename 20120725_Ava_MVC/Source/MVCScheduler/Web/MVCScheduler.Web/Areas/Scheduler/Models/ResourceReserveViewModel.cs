using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using MVCScheduler.Entities;
using MVCScheduler.Web.Models;

namespace MVCScheduler.Web.Areas.Scheduler.Models
{
	public class ResourceReserveViewModel : BaseViewModel
	{
		public ResourceReserveViewModel()
			: base()
		{
			this.StartDate = new SchedulerDateTime();
			this.EndDate = new SchedulerDateTime();
		}

		#region field / property

		[Display(Name = "リソースタイプID")]
		public Guid? ResourceTypeID { get; set; }

		[Display(Name = "リソースＩＤ")]
		public Guid? ResourceID { get; set; }

		[HiddenInput]
		public Guid ID { get; set; }

		[Display(Name = "件名")]
		[Required]
		public string Name { get; set; }

		[Display(Name = "予約開始日")]
		[Required]
		public SchedulerDateTime StartDate { get; set; }

		[Display(Name = "予約終了日")]
		[Required]
		public SchedulerDateTime EndDate { get; set; }

		[Display(Name = "予約ユーザID")]
		public Guid ReserveUserID { get; set; }

		[Display(Name = "メモ")]
		public string Memo { get; set; }

		[Timestamp]
		public byte[] Timestamp { get; set; }

		[Display(Name = "リソース名")]
		public string ResourceName { get; set; }

		[Display(Name = "予約ユーザ名")]
		public string ReserveUserName { get; set; }

		#endregion
	}
}