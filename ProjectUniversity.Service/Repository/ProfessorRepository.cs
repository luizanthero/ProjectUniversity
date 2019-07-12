using ProjectUniversity.Service.Context;
using ProjectUniversity.Service.Entity;
using ProjectUniversity.Service.Interface;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ProjectUniversity.Service.Repository
{
    public class ProfessorRepository : IRepository<Professor>
    {
        private readonly ServiceContext _context;

        public ProfessorRepository()
        {
            _context = new ServiceContext();
        }

        public void Create(Professor entity)
        {
            _context.Professores.Add(entity);
            _context.SaveChanges();
        }

        public List<Professor> GetAll()
        {
            return _context.Professores.ToList();
        }

        public void Remove(int id)
        {
            Professor professor = _context.Professores.Find(id);
            _context.Professores.Remove(professor);
            _context.SaveChanges();
        }

        public void Update(Professor entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
