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
	[Table("M_Resource")]
	[JsonObject]
	public class M_Resource : BaseEntity
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

		[Column("ResourceTypeID", TypeName = "uniqueidentifier")]
		[ForeignKey("ResourceType")]
		[JsonField(ForeignKey = "ResourceType")]
		public Guid ResourceTypeID { get; set; }

		[Column("Timestamp", TypeName = "timestamp")]
		[Timestamp]
		[JsonField]
		public byte[] Timestamp { get; set; }

		#endregion

		#region Relations

		public virtual M_ResourceType ResourceType { get; set; }

		public virtual ICollection<T_ResourceReserve> ReserveResources { get; set; }

		#endregion
	}
}
