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
	[Table("M_SystemUser")]
	[JsonObject]
	public class M_SystemUser
	{
		#region Fields

		[Column("ID", TypeName = "uniqueidentifier")]
		[JsonField]
		public Guid ID { get; set; }

		[Column("UserID", TypeName = "nvarchar")]
		[JsonField]
		public string UserID { get; set; }

		[Column("Password", TypeName = "nvarchar")]
		[JsonField]
		public string Password { get; set; }
		
		[Column("LastLogin", TypeName = "datetime")]
		[JsonField]
		public DateTime? LastLogin { get; set; }

		[Column("LastChangePassword", TypeName = "datetime")]
		[JsonField]
		public DateTime? LastChangePassword { get; set; }

		[Column("LoginFailCount", TypeName = "int")]
		[JsonField]
		public int LoginFailCount { get; set; }

		[Column("Timestamp", TypeName = "timestamp")]
		[Timestamp]
		[JsonField]
		public byte[] Timestamp { get; set; }

		#endregion

		#region Relations

		public virtual ICollection<M_AppUser> AppUsers { get; set; }

		#endregion
	}
}
