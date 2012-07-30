using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using MVCScheduler.Models;
using MVCScheduler.Repositories;
using MVCScheduler.Web.Models;

namespace MVCScheduler.Web.WorkerServices
{
	public class BaseWorkerService
	{
		public BaseWorkerService()
		{
			this.ResolveReferences();
		}

		public BaseWorkerService(Controller controller)
		{
			this.Controller = controller;
			this.ResolveReferences();
		}

		protected Controller Controller { get; set; }

		private void ResolveReferences()
		{
			using (var container = new UnityContainer())
			{
				container.LoadConfiguration();
				this.ResolveReferences(container);
			}
		}

		protected virtual void ResolveReferences(UnityContainer container)
		{
		}
	}
}