using ProjectUniversity.Service.Context;
using ProjectUniversity.Service.Entity;
using ProjectUniversity.Service.Interface;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ProjectUniversity.Service.Repository
{
    public class ProfessorDisciplinaRepository : IRepository<ProfessorDisciplina>
    {
        private readonly ServiceContext _context;

        public ProfessorDisciplinaRepository()
        {
            _context = new ServiceContext();
        }

        public List<Professor> GetProfessores()
        {
            return _context.Professores.ToList();
        }

        public List<Disciplina> GetDisciplinas()
        {
            return _context.Disciplinas.ToList();
        }

        public IQueryable<ProfessorDisciplina> GetQueryable()
        {
            return _context.ProfessorDisciplinas.Include(p => p.Disciplina).Include(p => p.Professor);
        }

        #region IRepository

        public void Create(ProfessorDisciplina entity)
        {
            _context.ProfessorDisciplinas.Add(entity);
            _context.SaveChanges();
        }

        public List<ProfessorDisciplina> GetAll()
        {
            return _context.ProfessorDisciplinas.ToList();
        }

        public ProfessorDisciplina GetById(int? id)
        {
            return _context.ProfessorDisciplinas.Find(id);
        }

        public void Remove(int id)
        {
            ProfessorDisciplina professorDisciplina = GetById(id);
            _context.ProfessorDisciplinas.Remove(professorDisciplina);
            _context.SaveChanges();
        }

        public void Update(ProfessorDisciplina entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        #endregion
    }
}
