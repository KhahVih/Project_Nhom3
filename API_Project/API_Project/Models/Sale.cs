namespace API_Project.Models
{
    public class Sale
    {
        public Sale()
        {
            ProductDetails = new HashSet<ProductDetail>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public double? Ratio { get; set; }
        public bool? IsShow { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }

        public virtual ICollection<ProductDetail> ProductDetails { get; set; }
    }
}
