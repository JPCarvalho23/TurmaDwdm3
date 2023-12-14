using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TurmaDwdm3.Data;
using TurmaDwdm3.Models;

namespace TurmaDwdm3.Pages.UCurriculares
{
    public class CreateModel : PageModel
    {
        private readonly TurmaDwdm3.Data.TurmaContext _context;

        public CreateModel(TurmaDwdm3.Data.TurmaContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Ucurricular Ucurricular { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Ucurricular == null || Ucurricular == null)
            {
                return Page();
            }

            _context.Ucurricular.Add(Ucurricular);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
