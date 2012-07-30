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
	[Table("T_Meeting")]
	[JsonObject]
	public class T_Meeting : BaseEntity
	{
		#region Fields

		[Column("ID", TypeName = "uniqueidentifier")]
		[JsonField]
		public Guid ID { get; set; }

		[Column("Name", TypeName = "nvarchar")]
		[JsonField]
		public string Name { get; set; }

		[Column("RoomResourceID", TypeName = "uniqueidentifier")]
		[ForeignKey("RoomResource")]
		[JsonField(ForeignKey = "RoomResource")]
		public Guid RoomResourceID { get; set; }

		[Column("StartDate", TypeName = "datetime")]
		[JsonField]
		public DateTime StartDate { get; set; }

		[Column("EndDate", TypeName = "datetime")]
		[JsonField]
		public DateTime EndDate { get; set; }

		[Column("OwnerUserID", TypeName = "uniqueidentifier")]
		[ForeignKey("OwnerUser")]
		[JsonField(ForeignKey = "OwnerUser")]
		public Guid OwnerUserID { get; set; }

		[Column("Memo", TypeName = "nvarchar")]
		[JsonField]
		public string Memo { get; set; }

		[Column("Timestamp", TypeName = "timestamp")]
		[Timestamp]
		[JsonField]
		public byte[] Timestamp { get; set; }

		#endregion

		#region Relations

		public virtual M_Resource RoomResource { get; set; }

		public virtual M_AppUser OwnerUser { get; set; }

		public virtual ICollection<T_MeetingInvitation> MeetingInvitations { get; set; }

		public virtual ICollection<T_UserSchedule> UserSchedules { get; set; }

		#endregion
	}
}
