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
    public class ResourceController : Controller
    {
		private ResourceWorkerService WorkerService = new ResourceWorkerService();
        
		//
        // GET: /Master/Resource/
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

		[HttpGet]
		[Authorize]
		[OutputCache(Duration = 0)]
		public JsonResult GetResources()
		{
			var resources = this.WorkerService.GetResourcesAsJson();
			var result = Json(resources.ToArray(), JsonRequestBehavior.AllowGet);

			return result;
		}

		[HttpPost]
		[Authorize]
		public ActionResult Create(ResourceViewModel viewModel)
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
		public ActionResult Edit(ResourceViewModel viewModel)
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
