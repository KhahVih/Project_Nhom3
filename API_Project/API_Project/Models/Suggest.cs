namespace API_Project.Models
{
    public class Suggest
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }

        public virtual Product? Product { get; set; }
    }
}
