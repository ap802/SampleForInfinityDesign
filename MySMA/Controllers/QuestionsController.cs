using System;
using System.Web.Mvc;
using MySMA.Models;
using MySMA.Repositories;
using MySMA.Services;

namespace MySMA.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly IQuestionBaseRepository _repository;
        private readonly IQuestionDefinitionService _questionDefinitionService;

        public QuestionsController()
            : this(new QuestionBaseRepository(), new QuestionDefinitionService())
        {

        }

        public QuestionsController(IQuestionBaseRepository repository, IQuestionDefinitionService questionDefinitionService)
        {
            _repository = repository;
            _questionDefinitionService = questionDefinitionService;
        }

        // GET: Questions/Create
        public ActionResult Create(Guid questionnaireId, QuestionDefinitionId? questionDefinitionId)
        {
            QuestionDefinitionBase questionDefinition;

            if (questionDefinitionId.HasValue)
            {
                // Get the specified question definition
                questionDefinition = _questionDefinitionService.GetDefinition(questionDefinitionId.Value);
            }
            else
            {
                // Get the first question definition
                questionDefinition = _questionDefinitionService.GetFirstDefinition();
            }

            // I thought about using a ViewModel instead, but then believe we'd have three parallel class hierarchies:
            // QuestionDefinitionBase, QuestionBase, QuestionViewModelBase, and that seemed like it may be overkill,
            // but this should be evaluated if it seemed likt it becomes necessary. If it is implemented, QuestionBaseModelBinder
            // will need to be changed to QuestionViewModelBaseBinder.
            ViewBag.questionDefinition = questionDefinition;

            // Get a model of the appropriate type
            var model = questionDefinition.CreateQuestion();
            model.QuestionnaireId = questionnaireId;
            
            return View(model);
        }


        // POST: Questions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployerNameValue,PositionTitleValue,AddressValue,DebtorValue," +
                                                   "AmountOwedValue,MonthlyPaymentValue,NameValue,EmailValue,PhoneValue," +
                                                   "CurrencyValue,MonthValue,YearValue,DateValue,IntValue,SelectedAnswers," +
                                                   "SelectedAnswer,StreetValue,CityValue,StateValue,ZipValue," +
                                                   "StringValue,Id,QuestionDefinitionId,QuestionnaireId," +
                                                   "MonthDurationValue,YearDurationValue")] QuestionBase question)
        {
            if (ModelState.IsValid)
            {
                _repository.Insert(question);
                _repository.Save();

                var currentQuestionDefinition = _questionDefinitionService.GetDefinition(question.QuestionDefinitionId);
                var nextQuestionId = currentQuestionDefinition.GetNextQuestionId(question);               

                if (null == nextQuestionId)
                {
                    return RedirectToAction("Index", "Questionnaires");
                }

                var savedQuestion = _repository.Find(question.QuestionnaireId, nextQuestionId.Value);
                if (null != savedQuestion)
                {
                    return RedirectToAction("Edit",
                        new
                        {
                            questionnaireId = question.QuestionnaireId,
                            questionDefinitionId = nextQuestionId
                        });
                }
                return RedirectToAction("Create",
                    new
                    {
                        questionnaireId = question.QuestionnaireId,
                        questionDefinitionId = nextQuestionId
                    });
            }

            return View(question);
        }


        // GET: Questions/Edit/
        public ActionResult Edit(Guid questionnaireId, QuestionDefinitionId? questionDefinitionId)
        {
            QuestionDefinitionId questionDefinitionIdToEdit;

            if (questionDefinitionId.HasValue)
            {
                questionDefinitionIdToEdit = questionDefinitionId.Value;
            }
            else
            {
                questionDefinitionIdToEdit = _questionDefinitionService.FirstDefinitionId;
            }

            QuestionBase question = _repository.Find(questionnaireId, questionDefinitionIdToEdit);
            
            if (question == null)
            {
                // Create the question if we can't find it in the Repository
                return RedirectToAction("Create",
                    new
                    {
                        questionnaireId = questionnaireId ,
                        questionDefinitionId = questionDefinitionIdToEdit
                    });
            }

            var questionDefinition = _questionDefinitionService.GetDefinition(questionDefinitionIdToEdit);
            ViewBag.questionDefinition = questionDefinition;

            return View(question);
        }

        // POST: Questions/Edit
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployerNameValue,PositionTitleValue,AddressValue,DebtorValue," +
                                                   "AmountOwedValue,MonthlyPaymentValue,NameValue,EmailValue,PhoneValue," +
                                                   "CurrencyValue,MonthValue,YearValue,DateValue,IntValue,SelectedAnswers," +
                                                   "SelectedAnswer,StreetValue,CityValue,StateValue,ZipValue," +
                                                   "StringValue,Id,QuestionDefinitionId,QuestionnaireId," +
                                                    "MonthDurationValue,YearDurationValue")] QuestionBase question)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(question);
                _repository.Save();

                var currentQuestion = _questionDefinitionService.GetDefinition(question.QuestionDefinitionId);
                var nextQuestionId = currentQuestion.GetNextQuestionId(question);

                if (!nextQuestionId.HasValue)
                {
                    return RedirectToAction("Index", "Questionnaires");
                }
                else
                {
                    return RedirectToAction("Edit",
                        new
                        {
                            questionnaireId = question.QuestionnaireId,
                            questionDefinitionId = nextQuestionId
                        });
                }
            }

            return View(question);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repository.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
