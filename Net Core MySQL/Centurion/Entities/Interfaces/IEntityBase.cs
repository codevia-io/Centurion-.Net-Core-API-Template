using System;
namespace Entities.Interfaces
{
	public interface IEntityBase
	{
		public int Id { get; set; }
		public User CreatedBy { get; set; }
		public DateTime Created { get; set; }
		public DateTime? LastUpdate { get; set; }
	}
}

