namespace Forum.Models
{
    public class Thread
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Text { get; set; }
        public List<Reply>? Replies { get; set; }
        public int DiscussionSubjectId { get; set; }
        public DiscussionSubject? DiscussionSubject { get; set; } 
    }
}
