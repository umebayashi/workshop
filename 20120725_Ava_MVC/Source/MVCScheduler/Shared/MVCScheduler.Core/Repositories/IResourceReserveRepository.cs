using System;
using System.Collections.Generic;
using MVCScheduler.Entities;

namespace MVCScheduler.Repositories
{
	public interface IResourceReserveRepository : IBaseRepository<T_ResourceReserve>
	{
		IEnumerable<T_ResourceReserve> GetByResourceID(Guid resourceID);
	}
}
