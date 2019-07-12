using ProjectUniversity.Service.Entity;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ProjectUniversity.Service.Context
{
    public class ServiceContext : DbContext
    {
        private static readonly string connectionString = "Data Source=LUIZANTHERO-PC;Initial Catalog=ProjectUniversity_DB;Integrated Security=True;Pooling=False";

        public DbSet<Professor> Professores { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<ProfessorDisciplina> ProfessorDisciplinas { get; set; }

        public ServiceContext() : base(connectionString) { }

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
