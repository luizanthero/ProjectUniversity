using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectUniversity.Service.Context;
using ProjectUniversity.Service.Entity;
using ProjectUniversity.Service.Repository;

namespace ProjectUniversity.Web.Controllers
{
    public class ProfessorDisciplinaController : Controller
    {
        private readonly ProfessorDisciplinaRepository _professorDisciplina;

        public ProfessorDisciplinaController()
        {
            _professorDisciplina = new ProfessorDisciplinaRepository();
        }

        // GET: ProfessorDisciplina
        public ActionResult Index()
        {
            var professorDisciplinas = _professorDisciplina.GetQueryable();
            return View(professorDisciplinas.ToList());
        }

        // GET: ProfessorDisciplina/Details/5
        public ActionResult Details(int? professorId, int? disciplinaId)
        {
            if (professorId == null || disciplinaId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfessorDisciplina professorDisciplina = _professorDisciplina.GetById(professorId, disciplinaId);
            professorDisciplina.Disciplina = _professorDisciplina.GetDisciplinaById(disciplinaId);
            professorDisciplina.Professor = _professorDisciplina.GetProfessorById(professorId);
            if (professorDisciplina == null)
            {
                return HttpNotFound();
            }
            return View(professorDisciplina);
        }

        // GET: ProfessorDisciplina/Create
        public ActionResult Create()
        {
            ViewBag.DisciplinaId = new SelectList(_professorDisciplina.GetDisciplinas(), "Id", "Nome");
            ViewBag.ProfessorId = new SelectList(_professorDisciplina.GetProfessores(), "Id", "Nome");
            return View();
        }

        // POST: ProfessorDisciplina/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProfessorId,DisciplinaId")] ProfessorDisciplina professorDisciplina)
        {
            if (ModelState.IsValid)
            {
                _professorDisciplina.Create(professorDisciplina);
                return RedirectToAction("Index");
            }

            ViewBag.DisciplinaId = new SelectList(_professorDisciplina.GetDisciplinas(), "Id", "Nome", professorDisciplina.DisciplinaId);
            ViewBag.ProfessorId = new SelectList(_professorDisciplina.GetProfessores(), "Id", "Nome", professorDisciplina.ProfessorId);
            return View(professorDisciplina);
        }

        // GET: ProfessorDisciplina/Edit/5
        public ActionResult Edit(int? professorId, int? disciplinaId)
        {
            if (professorId == null || disciplinaId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfessorDisciplina professorDisciplina = _professorDisciplina.GetById(professorId, disciplinaId);
            professorDisciplina.Disciplina = _professorDisciplina.GetDisciplinaById(disciplinaId);
            professorDisciplina.Professor = _professorDisciplina.GetProfessorById(professorId);
            if (professorDisciplina == null)
            {
                return HttpNotFound();
            }
            ViewBag.DisciplinaId = new SelectList(_professorDisciplina.GetDisciplinas(), "Id", "Nome", professorDisciplina.DisciplinaId);
            ViewBag.ProfessorId = new SelectList(_professorDisciplina.GetProfessores(), "Id", "Nome", professorDisciplina.ProfessorId);
            return View(professorDisciplina);
        }

        // POST: ProfessorDisciplina/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProfessorId,DisciplinaId")] ProfessorDisciplina professorDisciplina)
        {
            professorDisciplina.Disciplina = _professorDisciplina.GetDisciplinaById(professorDisciplina.DisciplinaId);
            professorDisciplina.Professor = _professorDisciplina.GetProfessorById(professorDisciplina.ProfessorId);
            if (ModelState.IsValid)
            {
                _professorDisciplina.Update(professorDisciplina);
                return RedirectToAction("Index");
            }
            ViewBag.DisciplinaId = new SelectList(_professorDisciplina.GetDisciplinas(), "Id", "Nome", professorDisciplina.DisciplinaId);
            ViewBag.ProfessorId = new SelectList(_professorDisciplina.GetProfessores(), "Id", "Nome", professorDisciplina.ProfessorId);
            return View(professorDisciplina);
        }

        // GET: ProfessorDisciplina/Delete/5
        public ActionResult Delete(int? professorId, int? disciplinaId)
        {
            if (professorId == null || disciplinaId == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfessorDisciplina professorDisciplina = _professorDisciplina.GetById(professorId, disciplinaId);
            professorDisciplina.Disciplina = _professorDisciplina.GetDisciplinaById(disciplinaId);
            professorDisciplina.Professor = _professorDisciplina.GetProfessorById(professorId);
            if (professorDisciplina == null)
            {
                return HttpNotFound();
            }
            return View(professorDisciplina);
        }

        // POST: ProfessorDisciplina/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int professorId, int disciplinaId)
        {
            _professorDisciplina.Remove(professorId, disciplinaId);
            return RedirectToAction("Index");
        }
    }
}
