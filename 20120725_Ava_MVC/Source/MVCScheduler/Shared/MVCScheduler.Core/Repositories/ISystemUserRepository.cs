using System;
using System.Collections.Generic;
using MVCScheduler.Entities;

namespace MVCScheduler.Repositories
{
	public interface ISystemUserRepository : IBaseRepository<M_SystemUser>
	{
		M_SystemUser GetByUserID(string userID);
	}
}
