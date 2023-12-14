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
    public class IndexModel : PageModel
    {
        private readonly TurmaDwdm3.Data.TurmaContext _context;

        public IndexModel(TurmaDwdm3.Data.TurmaContext context)
        {
            _context = context;
        }

        public IList<Ucurricular> Ucurricular { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Ucurricular != null)
            {
                Ucurricular = await _context.Ucurricular.ToListAsync();
            }
        }
    }
}
