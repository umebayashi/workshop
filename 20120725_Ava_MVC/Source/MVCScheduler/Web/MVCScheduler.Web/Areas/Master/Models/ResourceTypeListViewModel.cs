using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCScheduler.Web.Models;

namespace MVCScheduler.Web.Areas.Master.Models
{
	public class ResourceTypeListViewModel : BaseViewModel
	{
		public ResourceTypeListViewModel()
			: base()
		{
		}

		public ResourceTypeViewModel[] Items { get; set; }
	}
}