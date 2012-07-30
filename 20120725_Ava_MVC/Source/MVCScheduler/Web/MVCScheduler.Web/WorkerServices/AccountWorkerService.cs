using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Security.Cryptography;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using MVCScheduler.Entities;
using MVCScheduler.Repositories;
using MVCScheduler.Web.Models;
using MVCScheduler.Web.Areas.Master.Models;

namespace MVCScheduler.Web.WorkerServices
{
	public class AccountWorkerService : BaseWorkerService
	{
		public AccountWorkerService()
			: base()
		{
		}

		protected override void ResolveReferences(UnityContainer container)
		{
			base.ResolveReferences(container);

			this.SystemUserRepository = container.Resolve<ISystemUserRepository>();
			this.CryptoManager = EnterpriseLibraryContainer.Current.GetInstance<CryptographyManager>();
		}

		private ISystemUserRepository SystemUserRepository { get; set; }

		private const string HASH_PROVIDER = "PasswordHasher";
		private CryptographyManager CryptoManager { get; set; }

		public LoginResult ValidateUser(LoginModel loginModel)
		{
			LoginResult loginResult = new LoginResult();

			var entity = this.SystemUserRepository.GetByUserID(loginModel.UserName);
			if (entity == null)
			{
				loginResult.Success = false;
				loginResult.Message = "ユーザ名またはパスワードが一致しません";

				entity.LoginFailCount++;
			}
			else
			{
				if (this.CryptoManager.CompareHash(HASH_PROVIDER, loginModel.Password, entity.Password))
				{
					loginResult.Success = true;
					loginResult.Message = "ログイン成功";

					entity.LastLogin = DateTime.Now;
					entity.LoginFailCount = 0;
				}
				else
				{
					loginResult.Success = false;
					loginResult.Message = "ユーザ名またはパスワードが一致しません";

					entity.LoginFailCount++;
				}
			}
			this.SystemUserRepository.SaveChanges();

			return loginResult;
		}

		public RegisterResult RegisterUser(RegisterModel registerModel)
		{
			var registerResult = new RegisterResult();

			var entity = this.SystemUserRepository.GetByUserID(registerModel.UserName);

			if (entity == null)
			{
				entity = this.SystemUserRepository.Create();
				entity.ID = Guid.NewGuid();
				entity.UserID = registerModel.UserName;
				entity.Password = this.CryptoManager.CreateHash(HASH_PROVIDER, registerModel.Password);
				entity.LastLogin = DateTime.Now;
				entity.LastChangePassword = DateTime.Now;

				this.SystemUserRepository.Add(entity);
				this.SystemUserRepository.SaveChanges();

				registerResult.Success = true;
			}

			return registerResult;
		}

		public ChangePasswordResult ChangePassword(string userName, ChangePasswordModel changePasswordModel)
		{
			var changePasswordResult = new ChangePasswordResult();

			var entity = this.SystemUserRepository.GetByUserID(userName);

			entity.Password = this.CryptoManager.CreateHash(HASH_PROVIDER, changePasswordModel.NewPassword);
			entity.LastChangePassword = DateTime.Now;

			this.SystemUserRepository.SaveChanges();

			return changePasswordResult;
		}
	}
}