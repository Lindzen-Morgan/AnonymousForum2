using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Forum;
using Forum.Models;

namespace Forum.DiscussionController
{
    public class IndexModel : PageModel
    {
        private readonly Forum.ApplicationDbContext _context;

        public IndexModel(Forum.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<DiscussionSubject> DiscussionSubject { get;set; } = default!;

        public async Task OnGetAsync()
        {
            DiscussionSubject = await _context.DiscussionSubjects.ToListAsync();
        }
    }
}
