using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCScheduler.Entities;

namespace MVCScheduler.Repositories
{
	public class ResourceRepository : BaseRepository, IResourceRepository
	{
		public IEnumerable<M_Resource> GetAll()
		{
			return this.DB.Resources.OrderBy(x => x.Code);
		}

		public M_Resource GetByID(Guid id)
		{
			return this.DB.Resources.Find(id);
		}

		public M_Resource GetByCode(string code)
		{
			return this.DB.Resources.Where(x => x.Code == code).First();
		}

		public M_Resource Create()
		{
			return this.DB.Resources.Create();
		}

		public void Add(M_Resource entity)
		{
			this.DB.Resources.Add(entity);
		}

		public void Remove(M_Resource entity)
		{
			this.DB.Resources.Remove(entity);
		}

		public IEnumerable<M_Resource> GetByResourceTypeCode(string resourceTypeCode)
		{
			return this.DB.Resources.Where(x => x.ResourceType.Code == resourceTypeCode).OrderBy(x => x.Code);
		}

		public IEnumerable<M_Resource> GetByResourceTypeID(Guid resourceTypeID)
		{
			return this.DB.Resources.Where(x => x.ResourceTypeID == resourceTypeID).OrderBy(x => x.Code);
		}
	}
}
