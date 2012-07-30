using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;
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
	public class AppUserWorkerService : BaseWorkerService
	{
		public AppUserWorkerService()
			: base()
		{
		}

		protected override void ResolveReferences(UnityContainer container)
		{
			base.ResolveReferences(container);

			this.AppUserRepository = container.Resolve<IAppUserRepository>();
			this.SystemUserRepository = container.Resolve<ISystemUserRepository>();
		}

		private IAppUserRepository AppUserRepository { get; set; }
		private ISystemUserRepository SystemUserRepository { get; set; }

		public AppUserListViewModel GetListViewModel()
		{
			var viewModel = new AppUserListViewModel();
			var entities = this.AppUserRepository.GetAll().ToArray();

			viewModel.Items = entities
				.Select(x => EntityToViewModel(x))
				.OrderBy(x => x.Code)
				.ToArray();

			return viewModel;
		}

		public AppUserViewModel GetViewModelForCreate()
		{
			var viewModel = new AppUserViewModel();

			viewModel.SystemUsers = this.SystemUserRepository.GetAll().ToArray();

			return viewModel;
		}

		public AppUserViewModel GetViewModelForCreate(AppUserViewModel oldViewModel)
		{
			var viewModel = new AppUserViewModel();

			viewModel.Code = oldViewModel.Code;
			viewModel.Name = oldViewModel.Name;
			viewModel.SystemUserID = oldViewModel.SystemUserID;
			viewModel.SystemUsers = oldViewModel.SystemUsers;
			viewModel.Timestamp = oldViewModel.Timestamp;

			return viewModel;
		}

		public AppUserViewModel GetViewModelForEdit(Guid id)
		{
			var viewModel = new AppUserViewModel();

			var entity = this.AppUserRepository.GetByID(id);
			viewModel.ID = entity.ID;
			viewModel.Code = entity.Code;
			viewModel.Name = entity.Name;
			viewModel.SystemUserID = entity.SystemUserID;
			viewModel.Timestamp = entity.Timestamp;
			viewModel.SystemUsers = this.SystemUserRepository.GetAll().ToArray();
			viewModel.IsNew = false;

			return viewModel;
		}

		public AppUserViewModel GetViewModelForEdit(AppUserViewModel oldViewModel)
		{
			var viewModel = new AppUserViewModel();

			viewModel.ID = oldViewModel.ID;
			viewModel.Code = oldViewModel.Code;
			viewModel.Name = oldViewModel.Name;
			viewModel.SystemUserID = oldViewModel.SystemUserID;
			viewModel.Timestamp = oldViewModel.Timestamp;
			viewModel.SystemUsers = oldViewModel.SystemUsers;
			viewModel.IsNew = false;

			return viewModel;
		}

		public void CreateEntity(AppUserViewModel viewModel)
		{
			var entity = this.AppUserRepository.Create();

			entity.ID = Guid.NewGuid();
			entity.Code = viewModel.Code;
			entity.Name = viewModel.Name;
			entity.SystemUserID = viewModel.SystemUserID;
			entity.Timestamp = viewModel.Timestamp;

			this.AppUserRepository.Add(entity);
			this.AppUserRepository.SaveChanges();
		}

		public void UpdateEntity(AppUserViewModel viewModel)
		{
			var entity = this.AppUserRepository.GetByID(viewModel.ID);

			this.CheckConcurrency(viewModel, entity);

			entity.Code = viewModel.Code;
			entity.Name = viewModel.Name;
			entity.SystemUserID = viewModel.SystemUserID;

			this.AppUserRepository.SaveChanges();
		}

		public void RemoveEntity(AppUserViewModel viewModel)
		{
			var entity = this.AppUserRepository.GetByID(viewModel.ID);

			this.CheckConcurrency(viewModel, entity);

			this.AppUserRepository.Remove(entity);
			this.AppUserRepository.SaveChanges();
		}

		private void CheckConcurrency(AppUserViewModel viewModel, M_AppUser entity)
		{
			if (!entity.Timestamp.SequenceEqual(viewModel.Timestamp))
			{
				throw new DbUpdateConcurrencyException();
			}
		}

		private AppUserViewModel EntityToViewModel(M_AppUser entity)
		{
			return new AppUserViewModel
			{
				ID = entity.ID,
				Code = entity.Code,
				Name = entity.Name
			};
		}
	}
}