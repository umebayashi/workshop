using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCScheduler.Web.Models;

namespace MVCScheduler.Web.Areas.Master.Models
{
	public class ResourceTypeViewModel : BaseViewModel
	{
		public ResourceTypeViewModel()
			: base()
		{
		}

		#region field / property

		[HiddenInput]
		public Guid ID { get; set; }

		[Display(Name = "リソースタイプコード")]
		[Required]
		public string Code { get; set; }

		[Display(Name = "リソースタイプ名")]
		[Required]
		public string Name { get; set; }

		[HiddenInput]
		public byte[] Timestamp { get; set; }

		#endregion
	}
}