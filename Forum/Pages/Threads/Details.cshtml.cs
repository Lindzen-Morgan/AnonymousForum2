using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Forum;
using Forum.Models;

namespace Forum.ThreadController
{
    public class DetailsModel : PageModel
    {
        private readonly Forum.ApplicationDbContext _context;

        public DetailsModel(Forum.ApplicationDbContext context)
        {
            _context = context;
        }

        public Forum.Models.Thread Thread { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thread = await _context.Threads.FirstOrDefaultAsync(m => m.Id == id);
            if (thread == null)
            {
                return NotFound();
            }
            else
            {
                Thread = thread;
            }
            return Page();
        }
    }
}
