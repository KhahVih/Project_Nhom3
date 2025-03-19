using System.Drawing;

namespace API_Project.Models
{
    public class ProductDetail
    {
        public int? SizeId { get; set; }
        public int? ProductId { get; set; }
        public double? Price { get; set; }
        public int? SaleId { get; set; }
        public int Id { get; set; }
        public double? Quantity { get; set; }
        public int? ColorId { get; set; }

        public virtual Color? Color { get; set; }
        public virtual Product? Product { get; set; }
        public virtual Sale? Sale { get; set; }
        public virtual Size? Size { get; set; }
    }
}
