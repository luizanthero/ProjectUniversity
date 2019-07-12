namespace ProjectUniversity.Service.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Disciplina",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Periodo = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProfessorDisciplina",
                c => new
                    {
                        ProfessorId = c.Int(nullable: false),
                        DisciplinaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProfessorId, t.DisciplinaId })
                .ForeignKey("dbo.Disciplina", t => t.DisciplinaId, cascadeDelete: true)
                .ForeignKey("dbo.Professor", t => t.ProfessorId, cascadeDelete: true)
                .Index(t => t.ProfessorId)
                .Index(t => t.DisciplinaId);
            
            CreateTable(
                "dbo.Professor",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Sobrenome = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProfessorDisciplina", "ProfessorId", "dbo.Professor");
            DropForeignKey("dbo.ProfessorDisciplina", "DisciplinaId", "dbo.Disciplina");
            DropIndex("dbo.ProfessorDisciplina", new[] { "DisciplinaId" });
            DropIndex("dbo.ProfessorDisciplina", new[] { "ProfessorId" });
            DropTable("dbo.Professor");
            DropTable("dbo.ProfessorDisciplina");
            DropTable("dbo.Disciplina");
        }
    }
}
