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
        //Create new disc
        public async Task CreateDiscussionSubjectAsync(DiscussionSubject subject)
        {
            await DiscussionSubjects.AddAsync(subject);
            await SaveChangesAsync();

        }
        //read all disc
        
        public async Task<List<DiscussionSubject>> GetAllDiscussionSubjectsAsync()
        {
            return await DiscussionSubjects.ToListAsync();
        }
        //update disc
        
        public async Task UpdateDiscussionSubjectAsync(DiscussionSubject subject)
        {
            DiscussionSubjects.Update(subject);
            await SaveChangesAsync();
        }
        // Delete a DiscussionSubject
        public async Task DeleteDiscussionSubjectAsync(int id)
        {
            var subject = await DiscussionSubjects.FindAsync(id);
            if (subject != null)
            {
                DiscussionSubjects.Remove(subject);
                await SaveChangesAsync();
            }
        }
        // Create a new Thread
        public async Task CreateThreadAsync(Thread thread)
        {
            await Threads.AddAsync(thread);
            await SaveChangesAsync();
        }

        // Read all Threads
        public async Task<List<Thread>> GetAllThreadsAsync()
        {
            return await Threads.ToListAsync();
        }

        // Update existing Thread
        public async Task UpdateThreadAsync(Thread thread)
        {
            Threads.Update(thread);
            await SaveChangesAsync();
        }

        // Delete Thread
        public async Task DeleteThreadAsync(int id)
        {
            var thread = await Threads.FindAsync(id);
            if (thread != null)
            {
                Threads.Remove(thread);
                await SaveChangesAsync();
            }
        }

        // Create new Reply
        public async Task CreateReplyAsync(Reply reply)
        {
            await Replies.AddAsync(reply);
            await SaveChangesAsync();
        }

        // Read Replies
        public async Task<List<Reply>> GetAllRepliesAsync()
        {
            return await Replies.ToListAsync();
        }

        // Update existing Reply
        public async Task UpdateReplyAsync(Reply reply)
        {
            Replies.Update(reply);
            await SaveChangesAsync();
        }

        // Delete Reply
        public async Task DeleteReplyAsync(int id)
        {
            var reply = await Replies.FindAsync(id);
            if (reply != null)
            {
                Replies.Remove(reply);
                await SaveChangesAsync();
            }
        }

    }

}
