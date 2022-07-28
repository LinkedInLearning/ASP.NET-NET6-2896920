namespace EvaluationProduit.MVC.Models
{
    public class ModeleBase
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Description { get; set; }
        public string ImageThumbnailUrl { get; set; }
        public DateTime DateCreation { get; set; }
    }
}
