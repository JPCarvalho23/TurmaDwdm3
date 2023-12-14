using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TurmaDwdm3.Data;
using TurmaDwdm3.Models;

namespace TurmaDwdm3.Pages.Inscricoes
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
        ViewData["AlunoID"] = new SelectList(_context.Aluno, "AlunoID", "AlunoID");
        ViewData["UcurricularID"] = new SelectList(_context.Ucurricular, "UcurricularID", "UcurricularID");
            return Page();
        }

        [BindProperty]
        public Inscricao Inscricao { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Inscricao == null || Inscricao == null)
            {
                return Page();
            }

            _context.Inscricao.Add(Inscricao);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
