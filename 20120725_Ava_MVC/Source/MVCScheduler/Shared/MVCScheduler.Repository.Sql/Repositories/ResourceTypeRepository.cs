using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCScheduler.Entities;

namespace MVCScheduler.Repositories
{
	public class ResourceTypeRepository : BaseRepository, IResourceTypeRepository
	{
		public IEnumerable<M_ResourceType> GetAll()
		{
			return this.DB.ResourceTypes.OrderBy(x => x.Code);
		}

		public M_ResourceType GetByID(Guid id)
		{
			return this.DB.ResourceTypes.Find(id);
		}

		public M_ResourceType GetByCode(string code)
		{
			return this.DB.ResourceTypes.Where(x => x.Code == code).First();
		}

		public M_ResourceType Create()
		{
			return this.DB.ResourceTypes.Create();
		}

		public void Add(M_ResourceType entity)
		{
			this.DB.ResourceTypes.Add(entity);
		}

		public void Remove(M_ResourceType entity)
		{
			this.DB.ResourceTypes.Remove(entity);
		}
	}
}
