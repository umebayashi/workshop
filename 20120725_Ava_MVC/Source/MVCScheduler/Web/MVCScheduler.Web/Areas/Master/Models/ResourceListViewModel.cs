using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCScheduler.Web.Models;

namespace MVCScheduler.Web.Areas.Master.Models
{
	public class ResourceListViewModel : BaseViewModel
	{
		public ResourceListViewModel()
			: base()
		{
		}

		public ResourceViewModel[] Items { get; set; }
	}
}