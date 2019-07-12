using System.Collections.Generic;

namespace ProjectUniversity.Service.Entity
{
    public class Disciplina
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Periodo { get; set; }

        public ICollection<ProfessorDisciplina> ProfessorDisciplinas { get; set; }
    }
}
