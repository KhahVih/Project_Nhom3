namespace API_Project.Models
{
    public class FrontendLayoutImage
    {
        public int FrontendLayoutId { get; set; }
        public int ImageId { get; set; }
        public int? Index { get; set; }

        public virtual FrontendLayout FrontendLayout { get; set; } = null!;
        public virtual Image Image { get; set; } = null!;
    }
}
