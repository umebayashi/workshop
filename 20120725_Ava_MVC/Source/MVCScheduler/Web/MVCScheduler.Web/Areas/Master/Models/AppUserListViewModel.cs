using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MVCScheduler.Web.Models;

namespace MVCScheduler.Web.Areas.Master.Models
{
	public class AppUserListViewModel : BaseViewModel
	{
		public AppUserListViewModel()
			: base()
		{
		}

		#region field / property

		public AppUserViewModel[] Items { get; set; }

		#endregion

		#region method

		#endregion
	}
}