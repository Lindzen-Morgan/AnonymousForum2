using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Forum;
using Forum.Models;

namespace Forum.DiscussionController
{
    public class EditModel : PageModel
    {
        private readonly Forum.ApplicationDbContext _context;

        public EditModel(Forum.ApplicationDbContext context)
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

            var discussionsubject =  await _context.DiscussionSubjects.FirstOrDefaultAsync(m => m.Id == id);
            if (discussionsubject == null)
            {
                return NotFound();
            }
            DiscussionSubject = discussionsubject;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(DiscussionSubject).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DiscussionSubjectExists(DiscussionSubject.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DiscussionSubjectExists(int id)
        {
            return _context.DiscussionSubjects.Any(e => e.Id == id);
        }
    }
}
