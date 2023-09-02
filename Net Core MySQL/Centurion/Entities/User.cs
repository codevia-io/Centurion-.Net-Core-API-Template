using Entities.Interfaces;
using Enums;
namespace Entities
{
    public class User : EntityBase, IUser
    {
        public string FirsName { get; set; }
        public string? LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public int? Telephone { get; set; }
        public string Password { get; set; }
        public UserPermission permision { get; set; } = UserPermission.User;
    }
}