using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TurmaDwdm3.Data;
using TurmaDwdm3.Models;

namespace TurmaDwdm3.Pages.Alunos
{
    public class IndexModel : PageModel
    {
        private readonly TurmaDwdm3.Data.TurmaContext _context;

        public IndexModel(TurmaDwdm3.Data.TurmaContext context)
        {
            _context = context;
        }

        public string OrdenacaoCorrente { get; set; }
        public string OrdenacaoNome { get; set; }
        public string FiltroCorrente { get; set; }
        public PaginaList<Aluno> Alunos { get; set; } = default!;

        public async Task OnGetAsync(string ordenacao, string filtroCorrente, string filtroTexto, int? pageIndex)
        {
            OrdenacaoCorrente = ordenacao;
            OrdenacaoNome = String.IsNullOrEmpty(ordenacao) ? "nome_desc" : "";

            if (filtroTexto != null)
            {
                pageIndex = 1;
            }
            else
            {
                filtroTexto = filtroCorrente;
            }

            FiltroCorrente = filtroTexto;

            IQueryable<Aluno> alunoIq = from s in _context.Aluno select s;

            if (!String.IsNullOrEmpty(filtroTexto))
            {
                alunoIq = alunoIq.Where(s => s.Nome.Contains(filtroTexto) || s.Apelido.Contains(filtroTexto));
            }

            switch (ordenacao)
            {
                case "nome_desc":
                    alunoIq = alunoIq.OrderByDescending(s => s.Nome);
                    break;
                default:
                    alunoIq = alunoIq.OrderBy(s => s.Nome);
                    break;
            }

            int pageSize = 3;
            Alunos = await PaginaList<Aluno>.CreateAsync(alunoIq.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}