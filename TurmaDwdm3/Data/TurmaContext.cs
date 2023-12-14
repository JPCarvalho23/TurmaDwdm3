using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TurmaDwdm3.Models;

namespace TurmaDwdm3.Data
{
    public class TurmaContext : DbContext
    {
        public TurmaContext (DbContextOptions<TurmaContext> options)
            : base(options)
        {
        }

        public DbSet<TurmaDwdm3.Models.Aluno> Aluno { get; set; } = default!;

        public DbSet<TurmaDwdm3.Models.Ucurricular>? Ucurricular { get; set; }

        public DbSet<TurmaDwdm3.Models.Inscricao>? Inscricao { get; set; }
    }
}
