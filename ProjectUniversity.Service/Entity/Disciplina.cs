using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectUniversity.Service.Entity
{
    public class Disciplina
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nome da Disciplina")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Nome { get; set; }

        [Display(Name = "Período")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Periodo { get; set; }

        public ICollection<ProfessorDisciplina> ProfessorDisciplinas { get; set; }
    }
}
