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

namespace TurmaDwdm3.Pages.Inscricoes
{
    public class EditModel : PageModel
    {
        private readonly TurmaDwdm3.Data.TurmaContext _context;

        public EditModel(TurmaDwdm3.Data.TurmaContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Inscricao Inscricao { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Inscricao == null)
            {
                return NotFound();
            }

            var inscricao =  await _context.Inscricao.FirstOrDefaultAsync(m => m.InscricaoID == id);
            if (inscricao == null)
            {
                return NotFound();
            }
            Inscricao = inscricao;
           ViewData["AlunoID"] = new SelectList(_context.Aluno, "AlunoID", "AlunoID");
           ViewData["UcurricularID"] = new SelectList(_context.Ucurricular, "UcurricularID", "UcurricularID");
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

            _context.Attach(Inscricao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InscricaoExists(Inscricao.InscricaoID))
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

        private bool InscricaoExists(int id)
        {
          return (_context.Inscricao?.Any(e => e.InscricaoID == id)).GetValueOrDefault();
        }
    }
}
