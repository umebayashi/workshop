using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCScheduler.Models;
using MVCScheduler.Web.Areas.Master.Models;
using MVCScheduler.Web.Areas.Master.WorkerServices;

namespace MVCScheduler.Web.Areas.Master.Controllers
{
    public class ResourceTypeController : Controller
    {
		private ResourceTypeWorkerService WorkerService = new ResourceTypeWorkerService();

        //
        // GET: /Master/ResourceType/
		[HttpGet]
		[Authorize]
		public ActionResult Index()
        {
			var viewModel = this.WorkerService.GetListViewModel();

            return View(viewModel);
        }

		[HttpGet]
		[Authorize]
		public ActionResult Create()
		{
			var viewModel = this.WorkerService.GetViewModelForCreate();

			return View(viewModel);
		}

		[HttpPost]
		[Authorize]
		public ActionResult Create(ResourceTypeViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				this.WorkerService.CreateEntity(viewModel);
				return RedirectToAction("Index");
			}
			else
			{
				viewModel = this.WorkerService.GetViewModelForCreate(viewModel);
				return View(viewModel);
			}
		}

		[HttpGet]
		[Authorize]
		public ActionResult Edit(Guid id)
		{
			var viewModel = this.WorkerService.GetViewModelForEdit(id);

			return View(viewModel);
		}

		[HttpPost]
		[Authorize]
		public ActionResult Edit(ResourceTypeViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				this.WorkerService.UpdateEntity(viewModel);
				return RedirectToAction("Index");
			}
			else
			{
				viewModel = this.WorkerService.GetViewModelForEdit(viewModel);
				return View(viewModel);
			}
		}
    }
}
