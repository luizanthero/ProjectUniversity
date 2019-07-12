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

        #region Specific Methods

        public List<Professor> GetProfessores()
        {
            return _context.Professores.ToList();
        }

        public Professor GetProfessorById(int? id)
        {
            return _context.Professores.Find(id);
        }

        public List<Disciplina> GetDisciplinas()
        {
            return _context.Disciplinas.ToList();
        }

        public Disciplina GetDisciplinaById(int? id)
        {
            return _context.Disciplinas.Find(id);
        }

        public IQueryable<ProfessorDisciplina> GetQueryable()
        {
            return _context.ProfessorDisciplinas.Include(p => p.Disciplina).Include(p => p.Professor);
        }

        #endregion

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
            throw new System.NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Update(ProfessorDisciplina entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        #endregion

        public ProfessorDisciplina GetById(int? professorId, int? disciplinaId)
        {
            return _context.ProfessorDisciplinas.Find(professorId, disciplinaId);
        }

        public void Remove(int professorId, int disciplinaId)
        {
            ProfessorDisciplina professorDisciplina = GetById(professorId, disciplinaId);
            _context.ProfessorDisciplinas.Remove(professorDisciplina);
            _context.SaveChanges();
        }
    }
}
