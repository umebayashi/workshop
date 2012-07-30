using System;
using System.Collections.Generic;
using System.Data.Objects.DataClasses;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;

namespace MVCScheduler.Web.Models
{
	public class BaseViewModel
	{
		public BaseViewModel()
		{
		}

		public bool IsNew { get; set; }
	}
}