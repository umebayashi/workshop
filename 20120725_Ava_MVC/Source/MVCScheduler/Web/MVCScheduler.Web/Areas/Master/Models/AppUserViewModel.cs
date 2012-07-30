using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using MVCScheduler.Entities;
using MVCScheduler.Web.Models;

namespace MVCScheduler.Web.Areas.Master.Models
{
	public class AppUserViewModel : BaseViewModel
	{
		public AppUserViewModel()
			: base()
		{
		}

		#region field / property

		public Guid ID { get; set; }

		[Display(Name = "ユーザコード")]
		[Required]
		public string Code { get; set; }

		[Display(Name = "ユーザ名")]
		[Required]
		public string Name { get; set; }

		[Display(Name = "ログインユーザID")]
		public Guid? SystemUserID { get; set; }

		[HiddenInput]
		[Timestamp]
		public byte[] Timestamp { get; set; }

		public M_SystemUser[] SystemUsers { get; set; }

		public M_SystemUser SystemUser
		{
			get
			{
				if (this.SystemUserID.HasValue)
				{
					return this.SystemUsers.Where(x => x.ID == this.SystemUserID.Value).FirstOrDefault();
				}
				else
				{
					return null;
				}
			}
		}

		public IEnumerable<SelectListItem> SystemUsersAsListItem()
		{
			yield return new SelectListItem();

			foreach (var systemUser in this.SystemUsers)
			{
				yield return new SelectListItem
				{
					Selected = (this.SystemUserID.HasValue && this.SystemUserID.Value == systemUser.ID),
					Text = systemUser.UserID,
					Value = systemUser.ID.ToString()
				};
			}
		}

		#endregion
	}
}