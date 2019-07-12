using System.ComponentModel.DataAnnotations;

namespace ProjectUniversity.Service.Entity
{
    public class ProfessorDisciplina
    {
        public Professor Professor { get; set; }
        [Display(Name = "Professor")]
        public int ProfessorId { get; set; }

        public Disciplina Disciplina { get; set; }
        [Display(Name = "Disciplina")]
        public int DisciplinaId { get; set; }
    }
}
