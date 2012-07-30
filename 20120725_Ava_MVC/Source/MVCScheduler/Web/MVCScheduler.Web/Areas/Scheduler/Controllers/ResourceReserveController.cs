using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCScheduler.Models;
using MVCScheduler.Web.Areas.Scheduler.Models;
using MVCScheduler.Web.Areas.Scheduler.WorkerServices;


namespace MVCScheduler.Web.Areas.Scheduler.Controllers
{
    public class ResourceReserveController : Controller
    {
		public ResourceReserveController() : base()
		{
			this.WorkerService = new ResourceReserveWorkerService(this);
		}

		private ResourceReserveWorkerService WorkerService;

        //
        // GET: /Scheduler/ReserveResource/
		[HttpGet]
		[Authorize]
		public ActionResult Index()
        {
			var viewModel = this.WorkerService.GetListViewModel();

			return View(viewModel);
        }

		[HttpGet]
		[Authorize]
		public ActionResult Search(Guid resourceID)
		{
			var viewModel = this.WorkerService.GetListViewModel(resourceID);

			return View(viewModel);
		}

		[HttpPost]
		[Authorize]
		public ActionResult Search(ResourceReserveListViewModel sourceViewModel)
		{
			var viewModel = this.WorkerService.GetListViewModel(sourceViewModel);

			return PartialView("_SearchResult", viewModel);
		}

		[HttpGet]
		[Authorize]
		public ActionResult Details(Guid resourceReserveID)
		{
			var viewModel = this.WorkerService.GetViewModel(resourceReserveID);

			return View(viewModel);
		}

		[HttpGet]
		[Authorize]
		public ActionResult Edit(Guid resourceReserveID)
		{
			var viewModel = this.WorkerService.GetViewModelForEdit(resourceReserveID);

			return View(viewModel);
		}

		[HttpPost]
		[Authorize]
		public ActionResult Edit(ResourceReserveViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				this.WorkerService.UpdateEntity(viewModel);
				return RedirectToAction("Index");
			}
			else
			{
				viewModel = this.WorkerService.GetViewModelForEdit(viewModel.ID);
				return View(viewModel);
			}
		}

		[HttpPost]
		[Authorize]
		public ActionResult Delete(Guid resourceReserveID)
		{
			return RedirectToAction("Index");
		}

		[HttpGet]
		[Authorize]
		public ActionResult Create(Guid resourceID)
		{
			var viewModel = this.WorkerService.GetViewModelForCreate(resourceID);

			return View(viewModel);
		}

		[HttpPost]
		[Authorize]
		public ActionResult Create(ResourceReserveViewModel viewModel)
		{
			if (ModelState.IsValid)
			{
				this.WorkerService.CreateEntity(viewModel);
				return RedirectToAction("Index");
			}
			else
			{
				viewModel = this.WorkerService.GetViewModelForCreate(viewModel.ResourceID.Value);
				return View(viewModel);
			}
		}

		[HttpGet]
		[Authorize]
		[OutputCache(Duration = 0)]
		public JsonResult GetResourceTypes()
		{
			var resourceTypes = this.WorkerService.GetResourceTypesAsJson().ToArray();
			var result = Json(resourceTypes.ToArray(), JsonRequestBehavior.AllowGet);

			return result;
		}

		[HttpGet]
		[Authorize]
		[OutputCache(Duration = 0)]
		public JsonResult GetResources(string strResourceTypeID)
		{
			var resourceTypeID = Guid.Parse(strResourceTypeID);
			var resources = this.WorkerService.GetResourcesAsJson(resourceTypeID).ToArray();

			//var result = Json(resources.FirstOrDefault(), JsonRequestBehavior.AllowGet);
			var result = Json(resources.ToArray(), JsonRequestBehavior.AllowGet);

			return result;
		}

		[HttpGet]
		[Authorize]
		[OutputCache(Duration = 0)]
		public JsonResult GetResourceReserves(string strResourceID)
		{
			var resourceID = Guid.Parse(strResourceID);
			var resourceReserves = this.WorkerService.GetResourceReservesAsJson(resourceID);

			var result = Json(resourceReserves.ToArray(), JsonRequestBehavior.AllowGet);

			return result;
		}
    }
}
