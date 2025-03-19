namespace API_Project.Models
{
    public partial class Blog
    {
        public Blog()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Body { get; set; }
        public int? CategoryId { get; set; }
        public bool? IsPublish { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? Description { get; set; }
        public string? Tag { get; set; }
        public int? ImageId { get; set; }

        public virtual Category? Category { get; set; }
        public virtual Image? Image { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
