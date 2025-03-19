namespace API_Project.Models
{
    public class FrontendLayout
    {
        public FrontendLayout()
        {
            FrontendLayoutImages = new HashSet<FrontendLayoutImage>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? ParentId { get; set; }

        public virtual ICollection<FrontendLayoutImage> FrontendLayoutImages { get; set; }
    }
}
