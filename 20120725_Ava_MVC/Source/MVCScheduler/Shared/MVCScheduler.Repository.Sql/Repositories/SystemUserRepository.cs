using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCScheduler.Entities;

namespace MVCScheduler.Repositories
{
	public class SystemUserRepository : BaseRepository, ISystemUserRepository
	{
		public IEnumerable<M_SystemUser> GetAll()
		{
			return this.DB.SystemUsers.OrderBy(x => x.UserID);
		}

		public M_SystemUser GetByID(Guid id)
		{
			return this.DB.SystemUsers.Find(id);
		}

		public M_SystemUser GetByUserID(string userID)
		{
			return this.DB.SystemUsers.Where(x => x.UserID == userID).FirstOrDefault();
		}

		public M_SystemUser Create()
		{
			return this.DB.SystemUsers.Create();
		}

		public void Add(M_SystemUser entity)
		{
			this.DB.SystemUsers.Add(entity);
		}

		public void Remove(M_SystemUser entity)
		{
			this.DB.SystemUsers.Remove(entity);
		}
	}
}
