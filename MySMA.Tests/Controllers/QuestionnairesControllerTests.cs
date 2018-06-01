using System;
using System.Web.Mvc;
using NSubstitute;
using NUnit.Framework;
using MySMA.Controllers;
using MySMA.Models;
using MySMA.Repositories;
using NSubstitute.ReturnsExtensions;
using System.Collections.Generic;
using System.Linq;

namespace MySMA.Tests.Controllers
{
    // ReSharper disable InconsistentNaming
    // ReSharper disable PossibleNullReferenceException

    [TestFixture]
    public class QuestionnairesControllerTests
    {
        private IRepository<Questionnaire> _repository;
        private QuestionnairesController _controller;

        [SetUp]
        public void SetUp()
        {
            _repository = Substitute.For<IRepository<Questionnaire>>();
            _controller = new QuestionnairesController(_repository);
        }

        [Test]
        public void Create_POST_ValidModel_RedirectsToQuestionsController()
        {
            // Arrange
            var questionnaire = new Questionnaire();

            // Act
            var result = _controller.Create(questionnaire) as RedirectToRouteResult;

            // Assert
            Assert.AreEqual("Questions", result.RouteValues["controller"]);
        }

        [Test]
        public void Create_POST_ValidModel_InvokesQuestionsCreateAction()
        {
            // Arrange
            var questionnaire = new Questionnaire();

            // Act
            var result = _controller.Create(questionnaire) as RedirectToRouteResult;

            // Assert
            Assert.AreEqual("Create", result.RouteValues["action"]);
        }

        [Test]
        public void Create_POST_ValidModel_ProvidesQuestionnaireIdToQuestionsController()
        {
            // Arrange
            var questionnaire = new Questionnaire();
            var testGuid = Guid.NewGuid();

            // Simulate the Id for a new Questionnaire being assigned in Repository.Insert().
            _repository.Insert(Arg.Do<Questionnaire>(x => x.Id = testGuid));

            // Act
            var result = _controller.Create(questionnaire) as RedirectToRouteResult;

            // Assert
            Assert.AreEqual(testGuid, result.RouteValues["questionnaireId"]);
        }

        [Test]
        public void Index_Invoked_ReturnsView()
        {
            // Arrange
            //TODO resolve this test for empty Substiture repository
            var questionnaire = new List<Questionnaire>
            {
                new Questionnaire()
            };
            _repository.All.Returns(questionnaire.AsQueryable());

           // Act
           var result = _controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void Index_Invoked_CallsRepositoryAll()
        {
            // Arrange
            var questionnaires = new List<Questionnaire>();
            _repository.All.Returns(questionnaires.AsQueryable());

            // Act
            _controller.Index();

            // Assert
            var temp = _repository.Received().All;
        }

        [Test]
        public void Index_Invoked_ListSortedByLastName()
        {
            // Arrange
            var borrowers = new List<Questionnaire> {
                new Questionnaire { BorrowerLastName = "B" },
                new Questionnaire { BorrowerLastName = "C" },
                new Questionnaire { BorrowerLastName = "A" } };

            _repository.All.Returns(borrowers.AsQueryable());

            var expectedList = borrowers.OrderBy(x => x.BorrowerLastName);

            // Act
            var result = _controller.Index() as ViewResult;
            var resultingList = result.Model as IEnumerable<Questionnaire>;

            // Assert
            Assert.IsTrue(expectedList.SequenceEqual(resultingList));
        }

        [Test]
        public void Details_QuestionnaireNotFound_ReturnsHttpNotFound()
        {
            // Arrange
            _repository.Find(Arg.Any<Guid>()).ReturnsNull();

            //Act
            var result = _controller.Details(Arg.Any<Guid>());

            //Assert
            Assert.IsInstanceOf<HttpNotFoundResult>(result);
        }

        [Test]
        public void Details_Id_CallsRepositoryFind()
        {
            // Arrange

            // Act
            _controller.Details(Guid.NewGuid());

            // Assert
            _repository.Received(1).Find(Arg.Any<Guid>());
        }

        [Test]
        public void Details_Id_ProvidesIdParameterToRepositoryFind()
        {
            // Arrange
            var id = Guid.NewGuid();

            // Act
            _controller.Details(id);

            // Assert
            _repository.Received(1).Find(id);
        }

        [Test]
        public void Details_Id_ReturnsView()
        {
            // Arrange
            var questionnaire = new Questionnaire();
            _repository.Find(Arg.Any<Guid>()).Returns(questionnaire);

            // Act
            var result = _controller.Details(Arg.Any<Guid>()) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void Details_Id_ProvdesQuestionnaireToView()
        {
            // Arrange
            var questionnaire = new Questionnaire();
            _repository.Find(Arg.Any<Guid>()).Returns(questionnaire);

            // Act
            var result = _controller.Details(Guid.NewGuid()) as ViewResult;

            // Assert
            var model = result.Model as Questionnaire;

            Assert.IsNotNull(model);
        }

        [Test]
        public void Create_GET_Invoked_ReturnsView()
        {
            // Arrange

            // Act
            var result = _controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);

        }

        [Test]
        public void Create_GET_Invoked_ViewBagHasSuffixes()
        {
            // Arrange

            // Act 
            var result = _controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result.ViewBag.suffixes);
        }

        [Test]
        public void Create_POST_ValidModel_CallsRepositoryInsert()
        {
            // Arrange
            var questionnaire = new Questionnaire();

            // Act
            var result = _controller.Create(questionnaire);

            // Assert
            Assert.IsTrue(_controller.ModelState.IsValid);
        }

        [Test]
        public void Create_POST_ValidModel_ProvidesModelParameterValueToRepository()
        {
            // Arrange
            var questionnaire = new Questionnaire();

            // Act
            var result = _controller.Create(questionnaire);

            // Assert
            _repository.Received(1).Insert(questionnaire);
        }

        [Test]
        public void Create_POST_ValidModel_CallsRepositorySave()
        {
            // Arrange
            var questionnaire = new Questionnaire();

            // Act
            var result = _controller.Create(questionnaire);

            // Assert
            _repository.Received(1).Save();
        }

        [Test]
        public void Create_POST_InvalidModel_ReturnsView()
        {
            // Arrange
            _controller.ModelState.AddModelError("", "error");

            // Act
            var result = _controller.Create(new Questionnaire()) as ViewResult;

            // Assert
            Assert.AreEqual("", result.ViewName);
        }

        [Test]
        public void Edit_GET_Invoked_ViewBagHasSuffixes()
        {
            // Arrange
            _repository.Find(Arg.Any<Guid>()).Returns(new Questionnaire());
            // Act 
            var result = _controller.Edit(Guid.NewGuid()) as ViewResult;

            // Assert
            Assert.IsNotNull(result.ViewBag.suffixes);
        }

        [Test]
        public void Dispose_Invoked_CallsRepositoryDispose()
        {
            // Arrange

            // Act
            _controller.Dispose();

            // Assert
            _repository.Received().Dispose();
        }

    }

    // ReSharper restore InconsistentNaming
    // ReSharper restore PossibleNullReferenceException


}