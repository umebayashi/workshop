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
	[Table("T_UserSchedule")]
	[JsonObject]
	public class T_UserSchedule
	{
		#region Fields

		[Column("ID", TypeName = "uniqueidentifier")]
		[JsonField]
		public Guid ID { get; set; }

		[Column("Name", TypeName = "nvarchar")]
		[JsonField]
		public string Name { get; set; }

		[Column("OwnerUserID", TypeName = "uniqueidentifier")]
		[ForeignKey("OwnerUser")]
		[JsonField(ForeignKey = "OwnerUser")]
		public Guid OwnerUserID { get; set; }

		[Column("StartDate", TypeName = "datetime")]
		[JsonField]
		public DateTime StartDate { get; set; }

		[Column("EndDate", TypeName = "datetime")]
		[JsonField]
		public DateTime EndDate { get; set; }

		[Column("AllDay", TypeName = "bit")]
		public bool AllDay { get; set; }

		[Column("Place", TypeName = "nvarchar")]
		[JsonField]
		public string Place { get; set; }

		[Column("MeetingID", TypeName = "uniqueidentifier")]
		[ForeignKey("Meeting")]
		[JsonField(ForeignKey = "Meeting")]
		public Guid? MeetingID { get; set; }

		[Column("Memo", TypeName = "nvarchar")]
		[JsonField]
		public string Memo { get; set; }

		[Column("Timestamp", TypeName = "timestamp")]
		[Timestamp]
		[JsonField]
		public byte[] Timestamp { get; set; }

		#endregion

		#region Relations

		public virtual M_AppUser OwnerUser { get; set; }

		public virtual T_Meeting Meeting { get; set; }

		#endregion
	}
}
