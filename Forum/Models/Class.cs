namespace Forum.Models
{
    public class Reply
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public string? Text { get; set; }
        public int? ThreadId { get; set; }
        public Thread? Thread { get; set; }
    }
}
