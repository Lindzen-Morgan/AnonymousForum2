using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Forum;
using Forum.Models;

namespace Forum.Controller
{
    public class IndexModel : PageModel
    {
        private readonly Forum.ApplicationDbContext _context;

        public IndexModel(Forum.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Reply> Reply { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Reply = await _context.Replies
                .Include(r => r.Thread).ToListAsync();
        }
    }
}
