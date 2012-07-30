using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Security;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using MVCScheduler.Entities;
using MVCScheduler.Repositories;
using MVCScheduler.Web.Areas.Scheduler.Models;
using MVCScheduler.Web.Models;
using MVCScheduler.Web.WorkerServices;


namespace MVCScheduler.Web.Areas.Scheduler.WorkerServices
{
	public class ResourceReserveWorkerService : BaseWorkerService
	{
		#region constructor

		public ResourceReserveWorkerService()
			: base()
		{
		}

		public ResourceReserveWorkerService(Controller controller)
			: base(controller)
		{
		}

		#endregion

		#region field / property

		private IAppUserRepository AppUserRepository { get; set; }
		private ISystemUserRepository SystemUserRepository { get; set; }
		private IResourceTypeRepository ResourceTypeRepository { get; set; }
		private IResourceRepository ResourceRepository { get; set; }
		private IResourceReserveRepository ResourceReserveRepository { get; set; }

		#endregion

		#region method

		protected override void ResolveReferences(UnityContainer container)
		{
			base.ResolveReferences(container);

			this.AppUserRepository = container.Resolve<IAppUserRepository>();
			this.SystemUserRepository = container.Resolve<ISystemUserRepository>();
			this.ResourceTypeRepository = container.Resolve<IResourceTypeRepository>();
			this.ResourceRepository = container.Resolve<IResourceRepository>();
			this.ResourceReserveRepository = container.Resolve<IResourceReserveRepository>();
		}

		private M_AppUser GetCurrentAppUser()
		{
			var userID = this.Controller.User.Identity.Name;
			var systemUser = this.SystemUserRepository.GetByUserID(userID);
			var appUser = this.AppUserRepository.GetAll().Where(x => x.SystemUserID == systemUser.ID).FirstOrDefault();

			return appUser;
		}

		private ResourceReserveViewModel EntityToViewModel(T_ResourceReserve entity)
		{
			var viewModel = new ResourceReserveViewModel
			{
				ID = entity.ID,
				Name = entity.Name,
				ResourceID = entity.ResourceID,
				StartDate = new SchedulerDateTime(entity.StartDate),
				EndDate = new SchedulerDateTime(entity.EndDate),
				ReserveUserID = entity.ReserveUserID,
				Memo = entity.Memo,
				Timestamp = entity.Timestamp
			};
			if (entity.Resource != null)
			{
				viewModel.ResourceName = entity.Resource.Name;
			}
			if (entity.ReserveUser != null)
			{
				viewModel.ReserveUserName = entity.ReserveUser.Name;
			}
			return viewModel;
		}

		public ResourceReserveListViewModel GetListViewModel(Guid resourceID)
		{
			var viewModel = new ResourceReserveListViewModel();

			viewModel.ResourceTypes = this.ResourceTypeRepository.GetAll().ToArray();
			viewModel.Resources = this.ResourceRepository.GetAll().ToArray();

			viewModel.SearchResourceID = resourceID;
			viewModel.Items = this.ResourceReserveRepository.GetByResourceID(resourceID)
				.ToArray()
				.Select(x => this.EntityToViewModel(x))
				.ToArray();

			return viewModel;
		}

		public ResourceReserveListViewModel GetListViewModel(ResourceReserveListViewModel sourceViewModel = null)
		{
			var viewModel = new ResourceReserveListViewModel();

			viewModel.ResourceTypes = this.ResourceTypeRepository.GetAll().ToArray();
			viewModel.Resources = this.ResourceRepository.GetAll().ToArray();

			if (sourceViewModel != null)
			{
				viewModel.SearchResourceTypeID = sourceViewModel.SearchResourceTypeID;
				viewModel.SearchResourceID = sourceViewModel.SearchResourceID;
				viewModel.Items = this.ResourceReserveRepository.GetByResourceID(sourceViewModel.SearchResourceID.Value)
					.ToArray()
					.Select(x => this.EntityToViewModel(x))
					.ToArray();
			}

			return viewModel;
		}

		public ResourceReserveViewModel GetViewModel(Guid? resourceReserveID = null)
		{
			ResourceReserveViewModel viewModel;
			if (resourceReserveID.HasValue)
			{
				viewModel = this.EntityToViewModel(this.ResourceReserveRepository.GetByID(resourceReserveID.Value));
			}
			else
			{
				viewModel = new ResourceReserveViewModel();
				viewModel.ReserveUserID = this.GetCurrentAppUser().ID;
			}

			return viewModel;
		}

		public ResourceReserveViewModel GetViewModelForEdit(Guid resourceReserveID)
		{
			var entity = this.ResourceReserveRepository.GetByID(resourceReserveID);
			var viewModel = this.EntityToViewModel(entity);

			return viewModel;
		}

		public ResourceReserveViewModel GetViewModelForCreate(Guid resourceID)
		{
			var viewModel = new ResourceReserveViewModel();

			viewModel.ResourceID = resourceID;

			return viewModel;
		}

		public IEnumerable<object> GetResourceTypesAsJson()
		{
			var resourceTypes = this.ResourceTypeRepository.GetAll()
				.Select(x => new { id = x.ID, code = x.Code, name = x.Name });

			return resourceTypes;
		}

		public IEnumerable<object> GetResourcesAsJson(Guid resourceTypeID)
		{
			var resources = this.ResourceRepository.GetByResourceTypeID(resourceTypeID)
				.Select(x => new { id = x.ID, code = x.Code, name = x.Name });

			return resources;
		}

		public IEnumerable<object> GetResourceReservesAsJson(Guid resourceID)
		{
			var list = new List<object>();
			var entities = this.ResourceReserveRepository.GetByResourceID(resourceID).ToArray();
			foreach (var entity in entities)
			{
				var jsonResource = new { id = entity.Resource.ID, code = entity.Resource.Code, name = entity.Resource.Name };
				var jsonUser = new { id = entity.ReserveUser.ID, code = entity.ReserveUser.Code, name = entity.ReserveUser.Name };
				var jsonMain = new
				{
					id = entity.ID,
					name = entity.Name,
					resource = jsonResource,
					startDate = entity.StartDate.ToString("yyyy/MM/dd HH:mm"),
					endDate = entity.EndDate.ToString("yyyy/MM/dd HH:mm"),
					reserveUser = jsonUser,
					memo = entity.Memo,
					Timestamp = entity.Timestamp
				};
				list.Add(jsonMain);
			}

			return list;
		}

		public void CreateEntity(ResourceReserveViewModel viewModel)
		{
			var entity = this.ResourceReserveRepository.Create();

			entity.ID = Guid.NewGuid();
			entity.Name = viewModel.Name;
			entity.ResourceID = viewModel.ResourceID.Value;
			entity.StartDate = viewModel.StartDate.Value;
			entity.EndDate = viewModel.EndDate.Value;
			entity.ReserveUserID = this.GetCurrentAppUser().ID;
			entity.Memo = viewModel.Memo;

			this.ResourceReserveRepository.Add(entity);
			this.ResourceReserveRepository.SaveChanges();
		}

		public void UpdateEntity(ResourceReserveViewModel viewModel)
		{
			var entity = this.ResourceReserveRepository.GetByID(viewModel.ID);

			this.CheckConcurrency(viewModel, entity);

			entity.Name = viewModel.Name;
			entity.StartDate = viewModel.StartDate.Value;
			entity.EndDate = viewModel.EndDate.Value;
			entity.Memo = viewModel.Memo;
			entity.Timestamp = viewModel.Timestamp;

			this.ResourceReserveRepository.SaveChanges();
		}

		public void RemoveEntity(ResourceReserveViewModel viewModel)
		{
			var entity = this.ResourceReserveRepository.GetByID(viewModel.ID);

			this.CheckConcurrency(viewModel, entity);

			this.ResourceReserveRepository.Remove(entity);
			this.ResourceReserveRepository.SaveChanges();
		}

		private void CheckConcurrency(ResourceReserveViewModel viewModel, T_ResourceReserve entity)
		{
			if (!entity.Timestamp.SequenceEqual(viewModel.Timestamp))
			{
				throw new DbUpdateConcurrencyException();
			}
		}

		#endregion
	}
}