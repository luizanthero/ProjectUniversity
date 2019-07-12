using ProjectUniversity.Service.Entity;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ProjectUniversity.Service.Context
{
    public class ServiceContext : DbContext
    {
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<ProfessorDisciplina> ProfessorDisciplinas { get; set; }

        public ServiceContext() : base("DbProjectUniversity") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<ProfessorDisciplina>().HasKey(p => new
            {
                p.ProfessorId,
                p.DisciplinaId
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
