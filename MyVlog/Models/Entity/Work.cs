namespace MyVlog.Models.Entity
{
    public class Work
    {
        public int ID { get; set; }
        public string? Image { get; set; }
        public string? ImageURL { get; set; }
        public string? Title { get; set; }
        public string? Text { get; set; }
        public DateTime Date { get; set; }
    }
}
