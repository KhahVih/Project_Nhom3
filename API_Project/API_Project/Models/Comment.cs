namespace API_Project.Models
{
    public partial class Comment
    {
        public Comment()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }
        public int? Vote { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedAt { get; set; }
        public int? CustomerId { get; set; }
        public bool? IsShow { get; set; }

        public virtual Customer? Customer { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
