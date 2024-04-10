using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Forum;
using Forum.Models;

namespace Forum.Pages
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
            return Page();
        }

        [BindProperty]
        public DiscussionSubject DiscussionSubject { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.DiscussionSubjects.Add(DiscussionSubject);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
