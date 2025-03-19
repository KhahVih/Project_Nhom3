namespace API_Project.Models
{
    public partial class ImageProduc
    {
        public int ImageId { get; set; }
        public int ProductId { get; set; }
        public int? Index { get; set; }

        public virtual Image Image { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
