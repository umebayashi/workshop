using System;
using System.Collections.Generic;
using MVCScheduler.Entities;

namespace MVCScheduler.Repositories
{
	public interface IResourceRepository : IBaseRepository<M_Resource>
	{
		M_Resource GetByCode(string code);
		IEnumerable<M_Resource> GetByResourceTypeCode(string resourceTypeCode);
		IEnumerable<M_Resource> GetByResourceTypeID(Guid resourceTypeID);
	}
}
