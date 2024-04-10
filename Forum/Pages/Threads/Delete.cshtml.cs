using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Forum;
using Forum.Models; // Add this line to include Forum.Models namespace

namespace Forum.ThreadController
{
    public class DeleteModel : PageModel
    {
        private readonly Forum.ApplicationDbContext _context;

        public DeleteModel(Forum.ApplicationDbContext context)
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
            else
            {
                Thread = thread;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var thread = await _context.Threads.FindAsync(id);
            if (thread != null)
            {
                Thread = thread;
                _context.Threads.Remove(Thread);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
