using System;
using System.Linq;
using System.Web.Mvc;
using MySMA.Models;
using MySMA.Repositories;

namespace MySMA.Controllers
{
    public class QuestionnairesController : Controller
    {
        private IRepository<Questionnaire> _repository;

        public QuestionnairesController()
            : this(new Repository<Questionnaire>())
        {

        }

        public QuestionnairesController(IRepository<Questionnaire> repository)
        {
            _repository = repository;
        }

        // GET: Questionnaires
        public ActionResult Index()
        {
            var questionaires = _repository.All.OrderBy(q => q.BorrowerLastName).ToList();
            return View(questionaires);
        }

        // GET: Questionnaires/Details/5
        public ActionResult Details(Guid id)
        {
            Questionnaire questionnaire = _repository.Find(id);
            if (questionnaire == null)
            {
                return HttpNotFound();
            }
            return View(questionnaire);
        }

        // GET: Questionnaires/Create
        public ActionResult Create()
        {
            AddSuffixesToViewBag();
            return View();
        }

        // POST: Questionnaires/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,BorrowerFirstName,BorrowerMiddleInitial,BorrowerLastName,BorrowerSuffix,BorrowerEmail,BorrowerHomePhone,BorrowerCellPhone")] Questionnaire questionnaire)
        {
            if (ModelState.IsValid)
            {
                _repository.Insert(questionnaire);
                _repository.Save();
                return RedirectToAction("Create", "Questions", new {questionnaireId = questionnaire.Id});
            }

            return View(questionnaire);
        }

        // GET: Questionnaires/Edit/5
        public ActionResult Edit(Guid id)
        {
            Questionnaire questionnaire = _repository.Find(id);
            if (questionnaire == null)
            {
                return HttpNotFound();
            }

            AddSuffixesToViewBag();

            return View(questionnaire);
        }

        // POST: Questionnaires/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,BorrowerFirstName,BorrowerMiddleInitial,BorrowerLastName,BorrowerSuffix,BorrowerEmail,BorrowerHomePhone,BorrowerCellPhone")] Questionnaire questionnaire)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(questionnaire);
                _repository.Save();
                
                return RedirectToAction("Index");
            }
            return View(questionnaire);
        }

        // GET: Questionnaires/Delete/5
        public ActionResult Delete(Guid id)
        {
            Questionnaire questionnaire = _repository.Find(id);
            if (questionnaire == null)
            {
                return HttpNotFound();
            }
            return View(questionnaire);
        }

        // POST: Questionnaires/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Questionnaire questionnaire = _repository.Find(id);
            _repository.Delete(questionnaire);
            _repository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repository.Dispose();
            }
            base.Dispose(disposing);
        }
        private void AddSuffixesToViewBag()
        {
            // If our needs become more complex, we can introduce a ViewModel, but it felt
            // like overkill to introduce it now.
            ViewBag.suffixes = new SelectList(new[]
            {
                new SelectListItem {Text = "", Value = ""},
                new SelectListItem {Text = "Jr.", Value = "Jr."},
                new SelectListItem {Text = "Sr.", Value = "Sr."},
                new SelectListItem {Text = "II", Value = "II"},
                new SelectListItem {Text = "III", Value = "III"}
            }, "Text", "Value");
        }

    }
}
