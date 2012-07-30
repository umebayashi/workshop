using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCScheduler.Entities;

namespace MVCScheduler.Models
{
	public class MVCSchedulerDBContext : DbContext
	{
		public DbSet<M_AppUser> AppUsers { get; set; }

		public DbSet<M_Resource> Resources { get; set; }

		public DbSet<M_ResourceType> ResourceTypes { get; set; }

		public DbSet<M_SystemUser> SystemUsers { get; set; }

		public DbSet<T_Meeting> Meetings { get; set; }

		public DbSet<T_MeetingInvitation> MeetingInvitations { get; set; }

		public DbSet<T_ResourceReserve> ResourceReserves { get; set; }

		public DbSet<T_UserSchedule> UserSchedules { get; set; }
	}
}
