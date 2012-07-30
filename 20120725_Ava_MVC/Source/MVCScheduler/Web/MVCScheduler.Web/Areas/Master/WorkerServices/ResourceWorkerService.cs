using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using MVCScheduler.Entities;
using MVCScheduler.Repositories;
using MVCScheduler.Web.WorkerServices;
using MVCScheduler.Web.Areas.Master.Models;

namespace MVCScheduler.Web.Areas.Master.WorkerServices
{
	public class ResourceWorkerService : BaseWorkerService
	{
		public ResourceWorkerService()
			: base()
		{
			this.ResourceTypes = this.ResourceTypeRepository.GetAll().ToArray();
		}

		protected override void ResolveReferences(UnityContainer container)
		{
			base.ResolveReferences(container);

			this.ResourceRepository = container.Resolve<IResourceRepository>();
			this.ResourceTypeRepository = container.Resolve<IResourceTypeRepository>();
		}

		private IResourceRepository ResourceRepository { get; set; }
		private IResourceTypeRepository ResourceTypeRepository { get; set; }

		private M_ResourceType[] ResourceTypes { get; set; }

		public ResourceListViewModel GetListViewModel()
		{
			var viewModel = new ResourceListViewModel();

			viewModel.Items = this.ResourceRepository.GetAll()
				.Select(x => EntityToViewModel(x))
				.OrderBy(x => x.Code)
				.ToArray();

			return viewModel;
		}

		public ResourceViewModel GetViewModelForCreate()
		{
			var viewModel = new ResourceViewModel();

			viewModel.ResourceTypes = this.ResourceTypes;

			return viewModel;
		}

		public ResourceViewModel GetViewModelForCreate(ResourceViewModel oldViewModel)
		{
			var viewModel = new ResourceViewModel();

			viewModel.Code = oldViewModel.Code;
			viewModel.Name = oldViewModel.Name;
			viewModel.ResourceTypeID = oldViewModel.ResourceTypeID;
			viewModel.ResourceTypes = this.ResourceTypes;

			return viewModel;
		}

		public ResourceViewModel GetViewModelForEdit(Guid id)
		{
			var viewModel = new ResourceViewModel();

			var entity = this.ResourceRepository.GetByID(id);
			viewModel.ID = entity.ID;
			viewModel.Code = entity.Code;
			viewModel.Name = entity.Name;
			viewModel.ResourceTypeID = entity.ResourceTypeID;
			viewModel.ResourceTypes = this.ResourceTypes;

			return viewModel;
		}

		public ResourceViewModel GetViewModelForEdit(ResourceViewModel oldViewModel)
		{
			var viewModel = new ResourceViewModel();

			var entity = this.ResourceRepository.GetByID(oldViewModel.ID);
			viewModel.ID = entity.ID;
			viewModel.Code = oldViewModel.Code;
			viewModel.Name = oldViewModel.Name;
			viewModel.ResourceTypeID = oldViewModel.ResourceTypeID;
			viewModel.ResourceTypes = this.ResourceTypes;

			return viewModel;
		}

		public void CreateEntity(ResourceViewModel viewModel)
		{
			var entity = this.ResourceRepository.Create();

			entity.ID = Guid.NewGuid();
			entity.Code = viewModel.Code;
			entity.Name = viewModel.Name;
			entity.ResourceTypeID = viewModel.ResourceTypeID.Value;

			this.ResourceRepository.Add(entity);
			this.ResourceRepository.SaveChanges();
		}

		public void UpdateEntity(ResourceViewModel viewModel)
		{
			var entity = this.ResourceRepository.GetByID(viewModel.ID);

			entity.Code = viewModel.Code;
			entity.Name = viewModel.Name;
			entity.ResourceTypeID = viewModel.ResourceTypeID.Value;

			this.ResourceRepository.SaveChanges();
		}

		public IEnumerable<object> GetResourcesAsJson()
		{
			var resources = this.ResourceRepository.GetAll()
				.Select(x => new { id = x.ID, code = x.Code, name = x.Name });

			return resources;
		}

		private ResourceViewModel EntityToViewModel(M_Resource entity)
		{
			return new ResourceViewModel
			{
				ID = entity.ID,
				Code = entity.Code,
				Name = entity.Name,
				ResourceTypeID = entity.ResourceTypeID,
				ResourceTypes = this.ResourceTypes
			};
		}
	}
}