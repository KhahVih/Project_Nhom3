namespace API_Project.Models
{
    public partial class CategoryImage
    {
        public CategoryImage()
        {
            Images = new HashSet<Image>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? ParentId { get; set; }
        public bool? IsFrontEnd { get; set; }

        public virtual ICollection<Image> Images { get; set; }
    }
}
