using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TurmaDwdm3.Data;
using TurmaDwdm3.Models;

namespace TurmaDwdm3.Pages.UCurriculares
{
    public class DeleteModel : PageModel
    {
        private readonly TurmaDwdm3.Data.TurmaContext _context;

        public DeleteModel(TurmaDwdm3.Data.TurmaContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Ucurricular Ucurricular { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Ucurricular == null)
            {
                return NotFound();
            }

            var ucurricular = await _context.Ucurricular.FirstOrDefaultAsync(m => m.UcurricularID == id);

            if (ucurricular == null)
            {
                return NotFound();
            }
            else 
            {
                Ucurricular = ucurricular;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Ucurricular == null)
            {
                return NotFound();
            }
            var ucurricular = await _context.Ucurricular.FindAsync(id);

            if (ucurricular != null)
            {
                Ucurricular = ucurricular;
                _context.Ucurricular.Remove(Ucurricular);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
