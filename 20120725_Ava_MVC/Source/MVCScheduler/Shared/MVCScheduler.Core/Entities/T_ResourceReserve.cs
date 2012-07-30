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
	[Table("T_ResourceReserve")]
	[JsonObject]
	public class T_ResourceReserve : BaseEntity
	{
		#region Fields

		[Column("ID", TypeName = "uniqueidentifier")]
		[JsonField]
		public Guid ID { get; set; }

		[Column("Name", TypeName = "nvarchar")]
		[JsonField]
		public string Name { get; set; }

		[Column("ResourceID", TypeName = "uniqueidentifier")]
		[ForeignKey("Resource")]
		[JsonField(ForeignKey = "resource")]
		public Guid ResourceID { get; set; }

		[Column("StartDate", TypeName = "datetime")]
		[JsonField]
		public DateTime StartDate { get; set; }

		[Column("EndDate", TypeName = "datetime")]
		[JsonField]
		public DateTime EndDate { get; set; }

		[Column("ReserveUserID", TypeName = "uniqueidentifier")]
		[ForeignKey("ReserveUser")]
		[JsonField]
		public Guid ReserveUserID { get; set; }

		[Column("Memo", TypeName = "nvarchar")]
		[JsonField]
		public string Memo { get; set; }

		[Column("Timestamp", TypeName = "timestamp")]
		[Timestamp]
		[JsonField]
		public byte[] Timestamp { get; set; }

		#endregion

		#region Relations

		public virtual M_Resource Resource { get; set; }

		public virtual M_AppUser ReserveUser { get; set; }

		#endregion
	}
}
