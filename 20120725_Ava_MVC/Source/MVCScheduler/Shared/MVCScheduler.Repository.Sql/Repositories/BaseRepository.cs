using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCScheduler.Entities;
using MVCScheduler.Models;

namespace MVCScheduler.Repositories
{
	public class BaseRepository
	{
		public BaseRepository()
		{
			this.DB = new MVCSchedulerDBContext();
		}

		protected MVCSchedulerDBContext DB { get; private set; }

		public void SaveChanges()
		{
			this.DB.SaveChanges();
		}
	}
}
