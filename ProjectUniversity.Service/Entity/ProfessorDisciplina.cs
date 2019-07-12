namespace ProjectUniversity.Service.Entity
{
    public class ProfessorDisciplina
    {
        public Professor Professor { get; set; }
        public int ProfessorId { get; set; }

        public Disciplina Disciplina { get; set; }
        public int DisciplinaId { get; set; }
    }
}
