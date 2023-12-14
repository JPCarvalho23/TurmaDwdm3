using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TurmaDwdm3.Data;
using TurmaDwdm3.Models;

namespace TurmaDwdm3.Pages.Inscricoes
{
    public class DeleteModel : PageModel
    {
        private readonly TurmaDwdm3.Data.TurmaContext _context;

        public DeleteModel(TurmaDwdm3.Data.TurmaContext context)
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

            var inscricao = await _context.Inscricao.FirstOrDefaultAsync(m => m.InscricaoID == id);

            if (inscricao == null)
            {
                return NotFound();
            }
            else 
            {
                Inscricao = inscricao;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Inscricao == null)
            {
                return NotFound();
            }
            var inscricao = await _context.Inscricao.FindAsync(id);

            if (inscricao != null)
            {
                Inscricao = inscricao;
                _context.Inscricao.Remove(Inscricao);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
