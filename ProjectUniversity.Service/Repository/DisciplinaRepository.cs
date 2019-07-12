using ProjectUniversity.Service.Context;
using ProjectUniversity.Service.Entity;
using ProjectUniversity.Service.Interface;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace ProjectUniversity.Service.Repository
{
    public class DisciplinaRepository : IRepository<Disciplina>
    {
        private readonly ServiceContext _context;

        public DisciplinaRepository()
        {
            _context = new ServiceContext();
        }

        public void Create(Disciplina entity)
        {
            _context.Disciplinas.Add(entity);
            _context.SaveChanges();
        }

        public List<Disciplina> GetAll()
        {
            return _context.Disciplinas.ToList();
        }

        public void Remove(int id)
        {
            Disciplina disciplina = _context.Disciplinas.Find(id);
            _context.Disciplinas.Remove(disciplina);
            _context.SaveChanges();
        }

        public void Update(Disciplina entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
