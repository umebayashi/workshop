using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVCScheduler.Data;

namespace MVCScheduler.Entities
{
	[Table("M_AppUser")]
	[JsonObject]
	public class M_AppUser : BaseEntity
	{
		#region Fields

		[Column("ID", TypeName = "uniqueidentifier")]
		[JsonField]
		public Guid ID { get; set; }

		[Column("Code", TypeName = "nvarchar")]
		[JsonField]
		public string Code { get; set; }

		[Column("Name", TypeName = "nvarchar")]
		[JsonField]
		public string Name { get; set; }

		[Column("SystemUserID", TypeName = "uniqueidentifier")]
		[ForeignKey("SystemUser")]
		[JsonField]
		public Guid? SystemUserID { get; set; }

		[Column("Timestamp", TypeName = "timestamp")]
		[Timestamp]
		[JsonField]
		public byte[] Timestamp { get; set; }

		#endregion

		#region Relations

		public virtual M_SystemUser SystemUser { get; set; }

		public virtual ICollection<T_Meeting> Meetings { get; set; }

		public virtual ICollection<T_MeetingInvitation> MeetingInvitations { get; set; }

		public virtual ICollection<T_ResourceReserve> ResourceReserves { get; set; }

		#endregion
	}
}
