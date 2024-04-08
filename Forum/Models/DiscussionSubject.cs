namespace Forum.Models
{
    public class DiscussionSubject
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Thread>? Threads { get; set; }
    }
}
