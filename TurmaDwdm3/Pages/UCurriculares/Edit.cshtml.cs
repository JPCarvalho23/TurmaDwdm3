using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TurmaDwdm3.Data;
using TurmaDwdm3.Models;

namespace TurmaDwdm3.Pages.UCurriculares
{
    public class EditModel : PageModel
    {
        private readonly TurmaDwdm3.Data.TurmaContext _context;

        public EditModel(TurmaDwdm3.Data.TurmaContext context)
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

            var ucurricular =  await _context.Ucurricular.FirstOrDefaultAsync(m => m.UcurricularID == id);
            if (ucurricular == null)
            {
                return NotFound();
            }
            Ucurricular = ucurricular;
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

            _context.Attach(Ucurricular).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UcurricularExists(Ucurricular.UcurricularID))
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

        private bool UcurricularExists(int id)
        {
          return (_context.Ucurricular?.Any(e => e.UcurricularID == id)).GetValueOrDefault();
        }
    }
}
