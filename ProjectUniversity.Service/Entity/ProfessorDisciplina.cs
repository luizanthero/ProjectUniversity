using System.ComponentModel.DataAnnotations;

namespace ProjectUniversity.Service.Entity
{
    public class ProfessorDisciplina
    {
        public Professor Professor { get; set; }
        [Key]
        [Display(Name = "Professor(a)")]
        public int ProfessorId { get; set; }

        public Disciplina Disciplina { get; set; }
        [Key]
        [Display(Name = "Disciplina")]
        public int DisciplinaId { get; set; }
    }
}
