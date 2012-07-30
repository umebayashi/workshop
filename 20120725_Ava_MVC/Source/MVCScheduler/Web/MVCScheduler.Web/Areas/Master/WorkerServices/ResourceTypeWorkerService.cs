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
	public class ResourceTypeWorkerService : BaseWorkerService
	{
		public ResourceTypeWorkerService()
			: base()
		{
		}

		protected override void ResolveReferences(UnityContainer container)
		{
			base.ResolveReferences(container);

			this.ResourceTypeRespository = container.Resolve<IResourceTypeRepository>();
		}

		private IResourceTypeRepository ResourceTypeRespository { get; set; }

		public ResourceTypeListViewModel GetListViewModel()
		{
			var viewModel = new ResourceTypeListViewModel();

			viewModel.Items = this.ResourceTypeRespository.GetAll()
				.Select(x => EntityToViewModel(x))
				.OrderBy(x => x.Code)
				.ToArray();

			return viewModel;
		}

		public ResourceTypeViewModel GetViewModelForCreate()
		{
			var viewModel = new ResourceTypeViewModel();

			return viewModel;
		}

		public ResourceTypeViewModel GetViewModelForCreate(ResourceTypeViewModel oldViewModel)
		{
			var viewModel = new ResourceTypeViewModel();

			viewModel.Code = oldViewModel.Code;
			viewModel.Name = oldViewModel.Name;

			return viewModel;
		}

		public ResourceTypeViewModel GetViewModelForEdit(Guid id)
		{
			var viewModel = new ResourceTypeViewModel();

			var entity = this.ResourceTypeRespository.GetByID(id);
			viewModel.ID = entity.ID;
			viewModel.Code = entity.Code;
			viewModel.Name = entity.Name;
			viewModel.IsNew = false;

			return viewModel;
		}

		public ResourceTypeViewModel GetViewModelForEdit(ResourceTypeViewModel oldViewModel)
		{
			var viewModel = new ResourceTypeViewModel();

			viewModel.ID = oldViewModel.ID;
			viewModel.Code = oldViewModel.Code;
			viewModel.Name = oldViewModel.Name;

			return viewModel;
		}

		public void CreateEntity(ResourceTypeViewModel viewModel)
		{
			var entity = this.ResourceTypeRespository.Create();

			entity.ID = Guid.NewGuid();
			entity.Code = viewModel.Code;
			entity.Name = viewModel.Name;

			this.ResourceTypeRespository.Add(entity);
			this.ResourceTypeRespository.SaveChanges();
		}

		public void UpdateEntity(ResourceTypeViewModel viewModel)
		{
			var entity = this.ResourceTypeRespository.GetByID(viewModel.ID);

			entity.Code = viewModel.Code;
			entity.Name = viewModel.Name;

			this.ResourceTypeRespository.SaveChanges();
		}

		public void RemoveEntity(ResourceTypeViewModel viewModel)
		{
			var entity = this.ResourceTypeRespository.GetByID(viewModel.ID);

			this.ResourceTypeRespository.Remove(entity);
			this.ResourceTypeRespository.SaveChanges();
		}

		private ResourceTypeViewModel EntityToViewModel(M_ResourceType entity)
		{
			return new ResourceTypeViewModel
			{
				ID = entity.ID,
				Code = entity.Code,
				Name = entity.Name
			};
		}
	}
}