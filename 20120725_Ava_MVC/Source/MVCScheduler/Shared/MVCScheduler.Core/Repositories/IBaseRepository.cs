using System;
using System.Collections.Generic;
using MVCScheduler.Entities;

namespace MVCScheduler.Repositories
{
	public interface IBaseRepository<T>
	{
		IEnumerable<T> GetAll();
		T GetByID(Guid id);
		T Create();
		void Add(T entity);
		void Remove(T entity);
		void SaveChanges();
	}
}
