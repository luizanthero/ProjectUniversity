using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectUniversity.Service.Entity
{
    public class Professor
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Nome { get; set; }

        [Display(Name = "Sobrenome")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Sobrenome { get; set; }

        [NotMapped]
        public string FullName { get; set; }

        public ICollection<ProfessorDisciplina> ProfessorDisciplinas { get; set; }
    }
}
