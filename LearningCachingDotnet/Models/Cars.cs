namespace LearningCachingDotnet.Models
{
    public class Cars
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string brand { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

    }
}
