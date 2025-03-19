namespace API_Project.Models
{
    public class Size
    {
        public Size()
        {
            ProductDetails = new HashSet<ProductDetail>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<ProductDetail> ProductDetails { get; set; }
    }
}
