using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCScheduler.Entities;

namespace MVCScheduler.Repositories
{
	public class ResourceReserveRepository : BaseRepository, IResourceReserveRepository
	{
		public IEnumerable<T_ResourceReserve> GetAll()
		{
			return this.DB.ResourceReserves.OrderBy(x => x.Resource.Code).OrderBy(x => x.StartDate);
		}

		public T_ResourceReserve GetByID(Guid id)
		{
			return this.DB.ResourceReserves.Find(id);
		}

		public IEnumerable<T_ResourceReserve> GetByResourceID(Guid resourceID)
		{
			return this.DB.ResourceReserves.Where(x => x.ResourceID == resourceID).OrderBy(x => x.StartDate);
		}

		public T_ResourceReserve Create()
		{
			return this.DB.ResourceReserves.Create();
		}

		public void Add(T_ResourceReserve entity)
		{
			this.DB.ResourceReserves.Add(entity);
		}

		public void Remove(T_ResourceReserve entity)
		{
			this.DB.ResourceReserves.Remove(entity);
		}
	}
}
