using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectUniversity.Service.Entity
{
    public class Professor
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nome do Professor(a)")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Nome { get; set; }

        [Display(Name = "Sobrenome do Professor(a)")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Sobrenome { get; set; }

        public ICollection<ProfessorDisciplina> ProfessorDisciplinas { get; set; }
    }
}
