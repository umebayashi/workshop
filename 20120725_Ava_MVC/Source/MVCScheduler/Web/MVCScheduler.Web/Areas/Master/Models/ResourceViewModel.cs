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
	public class ResourceViewModel : BaseViewModel
	{
		public ResourceViewModel()
			: base()
		{
		}

		#region field / property

		[HiddenInput]
		public Guid ID { get; set; }

		[Display(Name = "リソースコード")]
		[Required]
		public string Code { get; set; }

		[Display(Name = "リソース名")]
		[Required]
		public string Name { get; set; }

		[Display(Name = "リソースタイプ")]
		[Required()]
		public Guid? ResourceTypeID { get; set; }

		[HiddenInput]
		public byte[] Timestamp { get; set; }

		public M_ResourceType[] ResourceTypes { get; set; }

		public M_ResourceType ResourceType
		{
			get
			{
				if (this.ResourceTypeID.HasValue)
				{
					return this.ResourceTypes.Where(x => x.ID == this.ResourceTypeID.Value).First();
				}
				else
				{
					return null;
				}
			}
		}

		public IEnumerable<SelectListItem> ResourceTypesAsListItem()
		{
			var listItems = this.ResourceTypes.Select((x, i) => new SelectListItem
			{
				Selected = 
					(this.ResourceTypeID.HasValue && this.ResourceTypeID.Value == x.ID) ||
					(!this.ResourceTypeID.HasValue && i == 0),
				Text = x.Name,
				Value = x.ID.ToString()
			});

			return listItems;
		}

		#endregion
	}
}