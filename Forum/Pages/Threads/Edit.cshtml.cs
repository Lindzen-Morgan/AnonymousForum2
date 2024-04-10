using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Forum;
using Forum.Models; // Add this line to include Forum.Models namespace

namespace Forum.ThreadController
{
    public class EditModel : PageModel
    {
        private readonly Forum.ApplicationDbContext _context;

        public EditModel(Forum.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Forum.Models.Thread Thread { get; set; } = default!; // Specify Forum.Models.Thread here

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
            Thread = thread;
            ViewData["DiscussionSubjectId"] = new SelectList(_context.DiscussionSubjects, "Id", "Id");
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

            _context.Attach(Thread).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ThreadExists(Thread.Id))
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

        private bool ThreadExists(int id)
        {
            return _context.Threads.Any(e => e.Id == id);
        }
    }
}
