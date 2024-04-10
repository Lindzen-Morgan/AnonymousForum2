using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Forum;
using Forum.Models;

namespace Forum.ThreadController
{
    public class IndexModel : PageModel
    {
        private readonly Forum.ApplicationDbContext _context;

        public IndexModel(Forum.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Forum.Models.Thread> Thread { get; set; } = default!;

        public async Task OnGetAsync()
        {
            Thread = await _context.Threads
                .Include(t => t.DiscussionSubject).ToListAsync();
        }
    }
}
