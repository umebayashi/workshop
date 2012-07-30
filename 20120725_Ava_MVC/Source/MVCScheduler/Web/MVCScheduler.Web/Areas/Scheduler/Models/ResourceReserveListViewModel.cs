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
	public class ResourceReserveListViewModel : BaseViewModel
	{
		#region constructor

		public ResourceReserveListViewModel()
			: base()
		{
			this.ResourceTypes = new M_ResourceType[0];
			this.Resources = new M_Resource[0];
			this.Items = new ResourceReserveViewModel[0];
			this.EditItem = new ResourceReserveViewModel();
		}

		#endregion

		#region field / property

		[Display(Name = "リソースタイプID")]
		public Guid? SearchResourceTypeID { get; set; }

		[Display(Name = "リソースＩＤ")]
		public Guid? SearchResourceID { get; set; }

		public M_ResourceType[] ResourceTypes { get; set; }

		public M_Resource[] Resources { get; set; }

		public ResourceReserveViewModel[] Items { get; set; }

		public ResourceReserveViewModel EditItem { get; set; }

		#endregion

		#region method

		public IEnumerable<SelectListItem> ResourceTypesAsListItem()
		{
			yield return new SelectListItem();

			foreach (var entity in this.ResourceTypes)
			{
				yield return new SelectListItem
				{
					Selected = (this.SearchResourceTypeID.HasValue && this.SearchResourceTypeID.Value == entity.ID),
					Text = entity.Name,
					Value = entity.ID.ToString()
				};
			}
		}

		public IEnumerable<SelectListItem> ResourcesAsListItem()
		{
			yield return new SelectListItem();

			foreach (var entity in this.Resources)
			{
				yield return new SelectListItem
				{
					Selected = (this.SearchResourceID.HasValue && this.SearchResourceID.Value == entity.ID),
					Text = entity.Name,
					Value = entity.ID.ToString()
				};
			}
		}

		#endregion
	}
}