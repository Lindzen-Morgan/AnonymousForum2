namespace Forum
{
    using Forum.Models;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<DiscussionSubject> DiscussionSubjects { get; set; }
        public DbSet<Thread> Threads { get; set; }
        public DbSet<Reply> Replies { get; set; }
    }

}
