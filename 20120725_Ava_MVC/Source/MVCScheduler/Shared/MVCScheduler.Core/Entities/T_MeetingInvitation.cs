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
	[Table("T_MeetingInvitation")]
	[JsonObject]
	public class T_MeetingInvitation : BaseEntity
	{
		#region Fields

		[Column("ID", TypeName = "uniqueidentifier")]
		[JsonField]
		public Guid ID { get; set; }

		[Column("MeetingID", TypeName = "uniqueidentifier")]
		[ForeignKey("Meeting")]
		[JsonField(ForeignKey = "Meeting")]
		public Guid MeetingID { get; set; }

		[Column("InviteeUserID", TypeName = "uniqueidentifier")]
		[ForeignKey("InviteeUser")]
		[JsonField(ForeignKey = "InviteeUser")]
		public Guid InviteeUserID { get; set; }

		[Column("AnswerStatus", TypeName = "int")]
		[JsonField]
		public int AnswerStatus { get; set; }

		[Column("AnswerDate", TypeName = "datetime")]
		[JsonField]
		public DateTime? AnswerDate { get; set; }

		[Column("Timestamp", TypeName = "timestamp")]
		[Timestamp]
		[JsonField]
		public byte[] Timestamp { get; set; }

		#endregion

		#region Relations

		public virtual T_Meeting Meeting { get; set; }

		public virtual M_AppUser InviteeUser { get; set; }

		#endregion
	}
}
