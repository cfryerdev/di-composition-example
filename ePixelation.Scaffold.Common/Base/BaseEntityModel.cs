using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ePixelation.Scaffold.Common.Base
{
	public abstract class BaseEntityModel
	{
		public BaseEntityModel()
		{
			Created = DateTime.UtcNow;
		}

		[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public virtual int Id { get; set; }

		[Required]
		public DateTime Created { get; set; }

		[Required]
		public int CreatedBy { get; set; }

		public DateTime? Modified { get; set; }

		public int? ModifiedBy { get; set; }
	}
}
