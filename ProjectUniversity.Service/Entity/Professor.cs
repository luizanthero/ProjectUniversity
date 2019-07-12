using System.Collections.Generic;

namespace ProjectUniversity.Service.Entity
{
    public class Professor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }

        public ICollection<ProfessorDisciplina> ProfessorDisciplinas { get; set; }
    }
}
