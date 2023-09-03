using System.ComponentModel.DataAnnotations;
using Entities.Interfaces;

namespace Entities
{
    public class EntityBase : IEntityBase
    {
        [Key]
        public int Id { get; set; }
        public User? CreatedBy { get; set; } = null;
        public DateTime Created { get; set; }
        public DateTime? LastUpdate { get; set; }
    }
}

