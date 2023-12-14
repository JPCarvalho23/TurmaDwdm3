using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TurmaDwdm3.Models
{
    public class Aluno
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int AlunoID { get; set; }

        [MaxLength(20)]
        public string Nome { get; set; } = string.Empty;

        [MaxLength(20)]
        public string Apelido { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        [Display(Name = "Data Inscrição")]
        public DateTime DataInscricao { get; set; }

        [Display(Name = "Nome Completo")]
        [MaxLength(20)]
        public string NomeCompleto
        {
            get { return Nome + " " + Apelido; }
        }
        public ICollection<Inscricao> Inscricoes { get; set; }
    }
}
