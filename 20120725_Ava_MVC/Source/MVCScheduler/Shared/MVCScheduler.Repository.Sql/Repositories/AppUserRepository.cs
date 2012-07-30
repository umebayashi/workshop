using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCScheduler.Entities;

namespace MVCScheduler.Repositories
{
	public class AppUserRepository : BaseRepository, IAppUserRepository
	{
		public IEnumerable<M_AppUser> GetAll()
		{
			return this.DB.AppUsers.OrderBy(x => x.Code);
		}

		public M_AppUser GetByID(Guid id)
		{
			return this.DB.AppUsers.Find(id);
		}

		public M_AppUser GetByCode(string code)
		{
			return this.DB.AppUsers.Where(x => x.Code == code).First();
		}

		public M_AppUser Create()
		{
			return this.DB.AppUsers.Create();
		}

		public void Add(M_AppUser entity)
		{
			this.DB.AppUsers.Add(entity);
		}

		public void Remove(M_AppUser entity)
		{
			this.DB.AppUsers.Remove(entity);
		}
	}
}
