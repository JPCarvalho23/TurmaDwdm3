using System.ComponentModel.DataAnnotations;

namespace TurmaDwdm3.Models
{
    public class Ucurricular
    {
        public int UcurricularID { get; set; }

        [Display(Name = "Unidade curricular")]
        [MaxLength(50)]
        public string NomeUc { get; set; } = string.Empty;

        [Display(Name = "Nº créditos")]
        public int Nrcreditos { get; set; }

        public ICollection<Inscricao> Inscricoes { get; set; }
    }
}
