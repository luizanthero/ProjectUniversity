using ProjectUniversity.Service.Context;
using ProjectUniversity.Service.Entity;
using ProjectUniversity.Service.Interface;
using System;
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

        #region IRepository

        public void Create(Professor entity)
        {
            try
            {
                _context.Professores.Add(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        public List<Professor> GetAll()
        {
            return _context.Professores.ToList();
        }

        public Professor GetById(int? id)
        {
            return _context.Professores.Find(id);
        }

        public void Remove(int id)
        {
            try
            {
                Professor professor = GetById(id);
                _context.Professores.Remove(professor);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error when remove", ex);
            }
        }

        public void Update(Professor entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error when update", ex);
            }
        }

        #endregion

    }
}
