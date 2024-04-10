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
    public class DeleteModel : PageModel
    {
        private readonly Forum.ApplicationDbContext _context;

        public DeleteModel(Forum.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DiscussionSubject DiscussionSubject { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var discussionsubject = await _context.DiscussionSubjects.FirstOrDefaultAsync(m => m.Id == id);

            if (discussionsubject == null)
            {
                return NotFound();
            }
            else
            {
                DiscussionSubject = discussionsubject;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var discussionsubject = await _context.DiscussionSubjects.FindAsync(id);
            if (discussionsubject != null)
            {
                DiscussionSubject = discussionsubject;
                _context.DiscussionSubjects.Remove(DiscussionSubject);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
