namespace TurmaDwdm3.Models
{
    public class Inscricao
    {
        public int InscricaoID { get; set; }
        public int UcurricularID { get; set; }
        public int AlunoID { get; set; }
        public Ucurricular Ucurricular { get; set; }
        public Aluno Aluno { get; set; }
    }
}
