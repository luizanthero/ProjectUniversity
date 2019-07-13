using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
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
            ViewBag.DisciplinaId = new SelectList(_professorDisciplina.GetDisciplinas(), "Id", "FullName");
            ViewBag.ProfessorId = new SelectList(_professorDisciplina.GetProfessores(), "Id", "FullName");
            return View();
        }

        // POST: ProfessorDisciplina/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProfessorId,DisciplinaId")] ProfessorDisciplina professorDisciplina)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _professorDisciplina.Create(professorDisciplina);
                    TempData["Success"] = "Registro criado com sucesso.";
                    ViewBag.DisciplinaId = new SelectList(_professorDisciplina.GetDisciplinas(), "Id", "FullName");
                    ViewBag.ProfessorId = new SelectList(_professorDisciplina.GetProfessores(), "Id", "FullName");
                }

                return View(professorDisciplina);
            }
            catch (InvalidOperationException IEx)
            {
                TempData["Error"] = IEx.Message;
                ViewBag.DisciplinaId = new SelectList(_professorDisciplina.GetDisciplinas(), "Id", "FullName");
                ViewBag.ProfessorId = new SelectList(_professorDisciplina.GetProfessores(), "Id", "FullName");
                return View();
            }
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
            ViewBag.DisciplinaId = new SelectList(_professorDisciplina.GetDisciplinas(), "Id", "FullName", professorDisciplina.DisciplinaId);
            ViewBag.ProfessorId = new SelectList(_professorDisciplina.GetProfessores(), "Id", "FullName", professorDisciplina.ProfessorId);
            return View(professorDisciplina);
        }

        // POST: ProfessorDisciplina/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProfessorId,DisciplinaId")] ProfessorDisciplina professorDisciplina)
        {
            try
            {
                string professorId = Request.QueryString["professorId"];
                string disciplinaId = Request.QueryString["disciplinaId"];

                professorDisciplina.Disciplina = _professorDisciplina.GetDisciplinaById(professorDisciplina.DisciplinaId);
                professorDisciplina.Professor = _professorDisciplina.GetProfessorById(professorDisciplina.ProfessorId);

                if (ModelState.IsValid)
                {
                    _professorDisciplina.Remove(Convert.ToInt32(professorId), Convert.ToInt32(disciplinaId));
                    _professorDisciplina.Create(professorDisciplina);
                    TempData["Success"] = "Registro atualizado com sucesso.";

                    ViewBag.DisciplinaId = new SelectList(_professorDisciplina.GetDisciplinas(), "Id", "FullName", professorDisciplina.DisciplinaId);
                    ViewBag.ProfessorId = new SelectList(_professorDisciplina.GetProfessores(), "Id", "FullName", professorDisciplina.ProfessorId);
                }
                
                return View(professorDisciplina);
            }
            catch (InvalidOperationException IEx)
            {
                TempData["Error"] = IEx.Message;
                ViewBag.DisciplinaId = new SelectList(_professorDisciplina.GetDisciplinas(), "Id", "FullName");
                ViewBag.ProfessorId = new SelectList(_professorDisciplina.GetProfessores(), "Id", "FullName");
                return View();
            }
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
            try
            {
                _professorDisciplina.Remove(professorId, disciplinaId);
                return RedirectToAction("Index");
            }
            catch (InvalidOperationException IEx)
            {
                TempData["Error"] = IEx.Message;
                return View();
            }
        }
    }
}
