using System;
using System.Collections.Generic;
using MVCScheduler.Entities;

namespace MVCScheduler.Repositories
{
	public interface IResourceTypeRepository : IBaseRepository<M_ResourceType>
	{
		M_ResourceType GetByCode(string code);
	}
}
