using System.Data;

namespace API_Project.Models
{
    public class Permission
    {
        public Permission()
        {
            Roles = new HashSet<Role>();
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
