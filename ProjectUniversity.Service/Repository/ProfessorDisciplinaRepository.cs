﻿using ProjectUniversity.Service.Context;
using ProjectUniversity.Service.Entity;
using ProjectUniversity.Service.Interface;
using System;
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
            _context.Professores.ToList().ForEach(item =>
            {
                item.FullName = $"{item.Nome} {item.Sobrenome}";
            });
            return _context.Professores.ToList();
        }

        public Professor GetProfessorById(int? id)
        {
            return _context.Professores.Find(id);
        }

        public List<Disciplina> GetDisciplinas()
        {
            _context.Disciplinas.ToList().ForEach(item =>
            {
                item.FullName = $"{item.Nome} - {item.Periodo}";
            });
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
            try
            {
                _context.ProfessorDisciplinas.Add(entity);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error when create", ex);
            }
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

        public ProfessorDisciplina GetById(int? professorId, int? disciplinaId)
        {
            return _context.ProfessorDisciplinas.Find(professorId, disciplinaId);
        }

        public void Remove(int professorId, int disciplinaId)
        {
            try
            {
                ProfessorDisciplina professorDisciplina = GetById(professorId, disciplinaId);
                _context.ProfessorDisciplinas.Remove(professorDisciplina);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error when remove", ex);
            }
        }
    }
}
