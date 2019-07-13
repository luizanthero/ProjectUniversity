using System;
using System.Net;
using System.Web.Mvc;
using ProjectUniversity.Service.Entity;
using ProjectUniversity.Service.Repository;

namespace ProjectUniversity.Web.Controllers
{
    public class ProfessorController : Controller
    {
        private readonly ProfessorRepository _professorRepository;

        public ProfessorController()
        {
            _professorRepository = new ProfessorRepository();
        }

        // GET: Professor
        public ActionResult Index()
        {
            return View(_professorRepository.GetAll());
        }

        // GET: Professor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professor professor = _professorRepository.GetById(id);
            if (professor == null)
            {
                return HttpNotFound();
            }
            return View(professor);
        }

        // GET: Professor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Professor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Sobrenome")] Professor professor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _professorRepository.Create(professor);
                    TempData["Success"] = "Registro criado com sucesso.";
                }

                return View();
            }
            catch (InvalidOperationException IEx)
            {
                TempData["Error"] = IEx.Message;
                return View();
            }
        }

        // GET: Professor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professor professor = _professorRepository.GetById(id);
            if (professor == null)
            {
                return HttpNotFound();
            }
            return View(professor);
        }

        // POST: Professor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Sobrenome")] Professor professor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _professorRepository.Update(professor);
                    TempData["Success"] = "Registro atualizado com sucesso.";
                }

                return View(professor);
            }
            catch (InvalidOperationException IEx)
            {
                TempData["Error"] = IEx.Message;
                return View();
            }
        }

        // GET: Professor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professor professor = _professorRepository.GetById(id);
            if (professor == null)
            {
                return HttpNotFound();
            }
            return View(professor);
        }

        // POST: Professor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                _professorRepository.Remove(id);
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
