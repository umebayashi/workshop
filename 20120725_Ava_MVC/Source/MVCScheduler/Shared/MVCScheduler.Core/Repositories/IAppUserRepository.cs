using System;
using System.Collections.Generic;
using MVCScheduler.Entities;

namespace MVCScheduler.Repositories
{
	public interface IAppUserRepository : IBaseRepository<M_AppUser>
	{
		M_AppUser GetByCode(string code);
	}
}
