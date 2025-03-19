namespace API_Project.Models
{
    public partial class Category
    {
        public Category()
        {
            Blogs = new HashSet<Blog>();
            Images = new HashSet<Image>();
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public int? ParentId { get; set; }
        public bool? IsShow { get; set; }
        public bool? IsBlog { get; set; }
        public bool? IsNew { get; set; }
        public bool? TopMenu { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }
        public virtual ICollection<Image> Images { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
