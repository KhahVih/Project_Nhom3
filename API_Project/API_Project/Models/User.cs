namespace API_Project.Models
{
    public class User
    {
        public User()
        {
            Permissions = new HashSet<Permission>();
        }

        public int Id { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool? IsBlock { get; set; }
        public bool? IsDelete { get; set; }
        public bool? IsAdmin { get; set; }
        public string? Fullname { get; set; }

        public virtual ICollection<Permission> Permissions { get; set; }
    }
}
