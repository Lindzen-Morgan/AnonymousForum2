using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Forum;
using Forum.Models; // Add this line to include Forum.Models namespace

namespace Forum.ThreadController
{
    public class CreateModel : PageModel
    {
        private readonly Forum.ApplicationDbContext _context;

        public CreateModel(Forum.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["DiscussionSubjectId"] = new SelectList(_context.DiscussionSubjects, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public Forum.Models.Thread Thread { get; set; } = default!; // Specify Forum.Models.Thread here

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Threads.Add(Thread);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
