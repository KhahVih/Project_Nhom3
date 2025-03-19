namespace API_Project.Models
{
    public class Role
    {
        public Role()
        {
            Permistions = new HashSet<Permission>();
        }

        public int Id { get; set; }
        public string? ActionName { get; set; }
        public string? ActionCode { get; set; }

        public virtual ICollection<Permission> Permistions { get; set; }
    }
}
