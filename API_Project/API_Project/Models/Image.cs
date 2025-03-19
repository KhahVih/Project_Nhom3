namespace API_Project.Models
{
    public partial class Image
    {
        public Image()
        {
            Blogs = new HashSet<Blog>();
            FrontendLayoutImages = new HashSet<FrontendLayoutImage>();
            ImageProducs = new HashSet<ImageProduc>();
        }
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Link { get; set; }
        public int? CategoryImageId { get; set; }
        public string? Size { get; set; }
        public int? Index { get; set; }
        public string? LinkProduct { get; set; }
        public int? CategorId { get; set; }
        public int? IsMobile { get; set; }

        public virtual Category? Categor { get; set; }
        public virtual CategoryImage? CategoryImage { get; set; }
        public virtual ICollection<Blog> Blogs { get; set; }
        public virtual ICollection<FrontendLayoutImage> FrontendLayoutImages { get; set; }
        public virtual ICollection<ImageProduc> ImageProducs { get; set; }
    }
}
