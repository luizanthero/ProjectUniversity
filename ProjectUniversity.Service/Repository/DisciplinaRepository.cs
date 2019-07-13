using ProjectUniversity.Service.Context;
using ProjectUniversity.Service.Entity;
using ProjectUniversity.Service.Interface;
using System;
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

        #region IRepository

        public void Create(Disciplina entity)
        {
            try
            {
                _context.Disciplinas.Add(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error when create", ex);
            }
        }

        public List<Disciplina> GetAll()
        {
            return _context.Disciplinas.ToList();
        }

        public Disciplina GetById(int? id)
        {
            return _context.Disciplinas.Find(id);
        }

        public void Remove(int id)
        {
            try
            {
                Disciplina disciplina = GetById(id);
                _context.Disciplinas.Remove(disciplina);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error when remove", ex);
            }
        }

        public void Update(Disciplina entity)
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
