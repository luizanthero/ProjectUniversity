using System.Net;
using System.Web.Mvc;
using ProjectUniversity.Service.Entity;
using ProjectUniversity.Service.Repository;

namespace ProjectUniversity.Web.Controllers
{
    public class DisciplinaController : Controller
    {
        private readonly DisciplinaRepository _disciplinaRepository;

        public DisciplinaController()
        {
            _disciplinaRepository = new DisciplinaRepository();
        }

        // GET: Disciplina
        public ActionResult Index()
        {
            return View(_disciplinaRepository.GetAll());
        }

        // GET: Disciplina/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disciplina disciplina = _disciplinaRepository.GetById(id);
            if (disciplina == null)
            {
                return HttpNotFound();
            }
            return View(disciplina);
        }

        // GET: Disciplina/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Disciplina/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Periodo")] Disciplina disciplina)
        {
            if (ModelState.IsValid)
            {
                _disciplinaRepository.Create(disciplina);
                TempData["Success"] = "Registro criado com sucesso.";
            }

            return View(disciplina);
        }

        // GET: Disciplina/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disciplina disciplina = _disciplinaRepository.GetById(id);
            if (disciplina == null)
            {
                return HttpNotFound();
            }
            return View(disciplina);
        }

        // POST: Disciplina/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Periodo")] Disciplina disciplina)
        {
            if (ModelState.IsValid)
            {
                _disciplinaRepository.Update(disciplina);
                TempData["Success"] = "Registro atualizado com sucesso.";
            }
            return View(disciplina);
        }

        // GET: Disciplina/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Disciplina disciplina = _disciplinaRepository.GetById(id);
            if (disciplina == null)
            {
                return HttpNotFound();
            }
            return View(disciplina);
        }

        // POST: Disciplina/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _disciplinaRepository.Remove(id);
            return RedirectToAction("Index");
        }
    }
}
