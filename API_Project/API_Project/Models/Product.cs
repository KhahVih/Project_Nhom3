using System.Xml.Linq;

namespace API_Project.Models
{
    public partial class Product
    {
        public Product()
        {
            ImageProducs = new HashSet<ImageProduc>();
            ProductDetails = new HashSet<ProductDetail>();
            Suggests = new HashSet<Suggest>();
            Blogs = new HashSet<Blog>();
            Catefories = new HashSet<Category>();
            Comments = new HashSet<Comment>();
        }

        public int Id { get; set; }
        public string? PosCode { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int? CategoryId { get; set; }
        public int? UserId { get; set; }
        public string? Fullname { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public double? Price { get; set; }
        public bool IsPublish { get; set; }
        public string? LinkPosName { get; set; }
        public double? Sale { get; set; }
        public string? Image { get; set; }
        public string? Tag { get; set; }
        public bool? IsTagBlog { get; set; }
        public int? Count { get; set; }

        public virtual ICollection<ImageProduc> ImageProducs { get; set; }
        public virtual ICollection<ProductDetail> ProductDetails { get; set; }
        public virtual ICollection<Suggest> Suggests { get; set; }

        public virtual ICollection<Blog> Blogs { get; set; }
        public virtual ICollection<Category> Catefories { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
