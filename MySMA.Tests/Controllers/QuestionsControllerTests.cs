using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using MySMA.Controllers;
using MySMA.Models;
using MySMA.Repositories;
using MySMA.Services;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
using NUnit.Framework;

namespace MySMA.Tests.Controllers
{
    // ReSharper disable InconsistentNaming
    // ReSharper disable PossibleNullReferenceException

    [TestFixture]
    public class QuestionsControllerTests
    {
        private QuestionsController _controller;
        private IQuestionBaseRepository _baseRepository;
        private IQuestionDefinitionService _questionDefinitionService;

        [SetUp]
        public void SetUp()
        {
            _baseRepository = Substitute.For<IQuestionBaseRepository>();
            _questionDefinitionService = Substitute.For<IQuestionDefinitionService>();
            _controller = new QuestionsController(_baseRepository, _questionDefinitionService);
        }

#region Create() GET
        [Test]
        public void Create_GET_NoQuestionDefinitionSpecified_ReturnsView()
        {
            // Arrange
            var testQuestionDefinition = new IntegerQuestionDefinition { DefaultNextQuestionId = QuestionDefinitionId.ChildAge };
            _questionDefinitionService.GetFirstDefinition().Returns(testQuestionDefinition);

            // Act
            var result = _controller.Create(Guid.NewGuid(), null) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void Create_GET_NoQuestionDefinitionSpecified_AddsQuestionDefinitiontToViewBag()
        {
            // Arrange
            var testQuestionDefinition = new IntegerQuestionDefinition { PromptText = "Testing" };
            _questionDefinitionService.GetFirstDefinition().Returns(testQuestionDefinition);

            // Act
            var result = _controller.Create(Guid.NewGuid(), null) as ViewResult;

            // Assert
            var definition = result.ViewBag.questionDefinition as QuestionDefinitionBase;
            Assert.IsNotNull(definition);
        }

        [Test]
        public void Create_GET_NoQuestionDefinitionSpecified_QuestionPromptInViewBagIsForFirstQuestion()
        {
            // Arrange
            var testQuestionDefinition = new IntegerQuestionDefinition {PromptText = "Testing"};
            _questionDefinitionService.GetFirstDefinition().Returns(testQuestionDefinition);
   
            // Act
            var result = _controller.Create(Guid.NewGuid(), null) as ViewResult;

            // Assert
            var definition = result.ViewBag.questionDefinition as QuestionDefinitionBase;
            Assert.AreEqual("Testing", definition.PromptText);
        }

        // Uses two parameters to verify one type is not hard-coded. We don't need to test all types, just two different ones.
        [TestCase("MySMA.Models.IntegerQuestionDefinition, MySMA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "MySMA.Models.IntegerQuestion, MySMA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null")]
        [TestCase("MySMA.Models.DateQuestionDefinition, MySMA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
            "MySMA.Models.DateQuestion, MySMA, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null")]
        public void Create_GET_NoQuestionDefinitionSpecified_CreatesCorrectType(string questionDefinitionType, string expectedQuestionType)
        {
            // Arrange
            var definitionType = Type.GetType(questionDefinitionType);
            QuestionDefinitionBase testQuestionDefinition = Activator.CreateInstance(definitionType) as QuestionDefinitionBase;
            testQuestionDefinition.PromptText = "Testing";

            _questionDefinitionService.GetFirstDefinition().Returns(testQuestionDefinition);

            // Act
            var result = _controller.Create(Guid.NewGuid(), null) as ViewResult;

            // Assert
            var model = result.Model as QuestionBase;
            var expectedType = Type.GetType(expectedQuestionType);
            Assert.IsInstanceOf(expectedType, model);
        }

        [Test]
        public void Create_GET_NoQuestionDefinitionSpecified_ProvidesModelToView()
        {
            // Arrange
            var testQuestionDefinition = new IntegerQuestionDefinition { DefaultNextQuestionId = QuestionDefinitionId.ChildAge };
            _questionDefinitionService.GetFirstDefinition().Returns(testQuestionDefinition);

            // Act
            var result = _controller.Create(Guid.NewGuid(), null) as ViewResult;

            // Assert
            var model = result.Model as IntegerQuestion;

            Assert.IsNotNull(model);
        }


        [Test]
        public void Create_GET_NoQuestionDefinitionSpecified_ModelHasQuestionIdFromFirstQuestion()
        {
            // Arrange
            var testQuestionDefinition = new IntegerQuestionDefinition { Id = QuestionDefinitionId.BorrowerAge };
            _questionDefinitionService.GetFirstDefinition().Returns(testQuestionDefinition);

            // Act
            var result = _controller.Create(Guid.NewGuid(), null) as ViewResult;

            // Assert
            var model = result.Model as IntegerQuestion;

            Assert.AreEqual(QuestionDefinitionId.BorrowerAge, model.QuestionDefinitionId);
        }

        [Test]
        public void Create_GET_QuestionDefinitionSpecified_ModelHasQuestionDefinitionIdFromService()
        {
            // Arrange
            var testQuestionDefinition = new IntegerQuestionDefinition { Id = QuestionDefinitionId.ChildAge };
            _questionDefinitionService.GetDefinition(Arg.Any<QuestionDefinitionId>()).Returns(testQuestionDefinition);

            // Act
            var result = _controller.Create(Guid.NewGuid(), Arg.Any<QuestionDefinitionId>()) as ViewResult;

            // Assert
            var model = result.Model as IntegerQuestion;

            Assert.AreEqual(QuestionDefinitionId.ChildAge, model.QuestionDefinitionId);
        }

        [Test]
        public void Create_GET_QuestionDefinitionSpecified_RequestsSpecifiedDefinitionFromQuestionDefinitionService()
        {
            // Arrange
            var testQuestionDefinition = new IntegerQuestionDefinition { DefaultNextQuestionId = QuestionDefinitionId.ChildAge };
            _questionDefinitionService.GetDefinition(Arg.Any<QuestionDefinitionId>()).Returns(testQuestionDefinition);

            // Act
            var result = _controller.Create(Guid.NewGuid(), QuestionDefinitionId.ChildAge) as ViewResult;

            // Assert
            _questionDefinitionService.Received().GetDefinition(QuestionDefinitionId.ChildAge);
        }

        [Test]
        public void Create_GET_QuestionDefinitionSpecified_ViewBaglHasPromptTextFromService()
        {
            // Arrange
            var testQuestionDefinition = new IntegerQuestionDefinition { PromptText = "Testing"};
            _questionDefinitionService.GetDefinition(Arg.Any<QuestionDefinitionId>()).Returns(testQuestionDefinition);

            // Act
            var result = _controller.Create(Guid.NewGuid(), QuestionDefinitionId.ChildAge) as ViewResult;

            // Assert
            var definition = result.ViewBag.questionDefinition as QuestionDefinitionBase;
            Assert.AreEqual("Testing", definition.PromptText);
        }

        [Test]
        public void Create_GET_NoQuestionDefinitionSpecified_ModelHasQuestionnaireIdFromParameter()
        {
            // Arrange
            var testQuestionDefinition = new IntegerQuestionDefinition { PromptText = "Testing"};
            _questionDefinitionService.GetFirstDefinition().Returns(testQuestionDefinition);
            var testGuid = Guid.NewGuid();

            // Act
            var result = _controller.Create(testGuid, null) as ViewResult;

            // Assert
            var model = result.Model as IntegerQuestion;

            Assert.AreEqual(testGuid, model.QuestionnaireId);
        }
        #endregion

#region Create() POST

        [Test]
        public void Create_POST_ValidModel_CallsRepositoryInsert()
        {
            // Arrange
            var testQuestionDefinition = new IntegerQuestionDefinition { DefaultNextQuestionId = QuestionDefinitionId.ChildAge };
            _questionDefinitionService.GetDefinition(Arg.Any<QuestionDefinitionId>()).Returns(testQuestionDefinition);
            var question = new IntegerQuestion();

            // Act
            _controller.Create(question);

            // Assert
            _baseRepository.Received(1).Insert(Arg.Any<IntegerQuestion>());
        }

        [Test]
        public void Create_POST_ValidModel_InsertsModelFromParameter()
        {
            // Arrange
            var testQuestionDefinition = new IntegerQuestionDefinition { DefaultNextQuestionId = QuestionDefinitionId.ChildAge };
            _questionDefinitionService.GetDefinition(Arg.Any<QuestionDefinitionId>()).Returns(testQuestionDefinition);
            var question = new IntegerQuestion();
            question.IntValue = 12345;

            // Act
            _controller.Create(question);

            // Assert
            _baseRepository.Received().Insert(Arg.Is<IntegerQuestion>(x => x.IntValue == 12345));
        }

        [Test]
        public void Create_POST_ValidModel_CallsRepositorySave()
        {
            // Arrange
            var testQuestionDefinition = new IntegerQuestionDefinition { DefaultNextQuestionId = QuestionDefinitionId.ChildAge };
            _questionDefinitionService.GetDefinition(Arg.Any<QuestionDefinitionId>()).Returns(testQuestionDefinition);
            var question = new IntegerQuestion();

            // Act
            _controller.Create(question);

            // Assert
            _baseRepository.Received(1).Save();
        }

        [Test]
        public void Create_POST_ThereIsANextQuestion_RedirectsToCreate()
        {
            // Arrange
            var testQuestionDefinition = new IntegerQuestionDefinition { DefaultNextQuestionId = QuestionDefinitionId.ChildAge };
            _questionDefinitionService.GetDefinition(Arg.Any<QuestionDefinitionId>()).Returns(testQuestionDefinition);
            var question = new IntegerQuestion {QuestionDefinitionId = QuestionDefinitionId.BorrowerAge};
            
            // Act
            var result = _controller.Create(question) as RedirectToRouteResult;

            // Assert
            Assert.AreEqual("Create", result.RouteValues["action"]);
        }

        [Test]
        public void Create_POST_ThereIsANextQuestion_IncludesCorrectQuestionnaireIdParameter()
        {
            // Arrange
            var testQuestionDefinition = new IntegerQuestionDefinition { DefaultNextQuestionId = QuestionDefinitionId.ChildAge };
            _questionDefinitionService.GetDefinition(Arg.Any<QuestionDefinitionId>()).Returns(testQuestionDefinition);
            var questionnaireId = Guid.NewGuid();
            var question = new IntegerQuestion { QuestionnaireId = questionnaireId };

            // Act
            var result = _controller.Create(question) as RedirectToRouteResult;

            // Assert
            Assert.AreEqual(questionnaireId, result.RouteValues["questionnaireId"]);
        }

        [Test]
        public void Create_POST_ThereIsANextQuestion_SpecifiesCorrectNextQuestionId()
        {
            // Arrange
            var testQuestionDefinition = new IntegerQuestionDefinition { DefaultNextQuestionId = QuestionDefinitionId.ChildAge };
            _questionDefinitionService.GetDefinition(Arg.Any<QuestionDefinitionId>()).Returns(testQuestionDefinition);

            var question = new IntegerQuestion {QuestionDefinitionId = QuestionDefinitionId.BorrowerAge};
            
            // Act
            var result = _controller.Create(question) as RedirectToRouteResult;

            // Assert
            Assert.AreEqual(QuestionDefinitionId.ChildAge, result.RouteValues["questionDefinitionId"]);
        }

        [Test]
        public void Create_POST_NoNextQuestion_RedirectToIndexAction()
        {
            // Arrange
            var testQuestionDefinition = new IntegerQuestionDefinition();
            _questionDefinitionService.GetDefinition(Arg.Any<QuestionDefinitionId>()).Returns(testQuestionDefinition);
            var question = new IntegerQuestion {QuestionDefinitionId = QuestionDefinitionId.ChildAge};

            // Act
            var result = _controller.Create(question) as RedirectToRouteResult;

            // Assert
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [Test]
        public void Create_POST_NoNextQuestion_RedirectToQuestionnairesController()
        {
            // Arrange
            var testQuestionDefinition = new IntegerQuestionDefinition();
            _questionDefinitionService.GetDefinition(Arg.Any<QuestionDefinitionId>()).Returns(testQuestionDefinition);
            var question = new IntegerQuestion { QuestionDefinitionId = QuestionDefinitionId.ChildAge };

            // Act
            var result = _controller.Create(question) as RedirectToRouteResult;

            // Assert
            Assert.AreEqual("Questionnaires", result.RouteValues["controller"]);
        }

        [Test]
        public void Create_POST_InvalidModel_ReturnsView()
        {
            // Arrange
            _controller.ModelState.AddModelError("", "error");

            // Act
            var result = _controller.Create(new IntegerQuestion()) as ViewResult;

            // Assert
            Assert.AreEqual("", result.ViewName);
        }

        [Test]
        public void Create_POST_NextQuestionAlreadyExist_RedirectsToEdit()
        {
            // Arrange
            var testQuestionDefinition = new IntegerQuestionDefinition { DefaultNextQuestionId = QuestionDefinitionId.ChildAge };
            _questionDefinitionService.GetDefinition(Arg.Any<QuestionDefinitionId>()).Returns(testQuestionDefinition);
            var question = new IntegerQuestion { QuestionDefinitionId = QuestionDefinitionId.BorrowerAge };
            _baseRepository.Find(Arg.Any<Guid>(), QuestionDefinitionId.ChildAge).Returns(new StringQuestion());

            // Act
            var result = _controller.Create(question) as RedirectToRouteResult;

            // Assert
            Assert.AreEqual("Edit", result.RouteValues["action"]);
        }

        #endregion

        #region Edit() GET

        [Test]
        public void Edit_GET_Invoked_CallsQuestionRepositoryFind()
        {
            // Arrange


            // Act
            _controller.Edit(Guid.NewGuid(), null);

            // Assert
            _baseRepository.Received(1).Find(Arg.Any<Guid>(), Arg.Any<QuestionDefinitionId>());
        }


        [Test]
        public void Edit_GET_NullQuestionDefinitionId_RetrievesFirstQuestionFromRepository()
        {
            // Arrange
            _questionDefinitionService.FirstDefinitionId.Returns(QuestionDefinitionId.BorrowerAge);

            // Act
            _controller.Edit(Guid.NewGuid(), null);

            // Assert
            _baseRepository.Received(1).Find(Arg.Any<Guid>(), Arg.Is(QuestionDefinitionId.BorrowerAge));
        }

        [Test]
        public void Edit_GET_FirstQuestionNotInRepository_RedirectsToCreate()
        {
            // Arrange
            _baseRepository.Find(Arg.Any<Guid>(), Arg.Any<QuestionDefinitionId>()).ReturnsNull();

            // Act
            var result = _controller.Edit(Guid.NewGuid(), null) as RedirectToRouteResult;

            // Assert
            Assert.AreEqual("Create", result.RouteValues["action"]);
        }

        [Test]
        public void Edit_GET_FirstQuestionNotInRepository_ProvidesQuestionnaireIdToCreate()
        {
            // Arrange
            _baseRepository.Find(Arg.Any<Guid>(), Arg.Any<QuestionDefinitionId>()).ReturnsNull();
            var questionnaireId = Guid.NewGuid();

            // Act
            var result = _controller.Edit(questionnaireId, null) as RedirectToRouteResult;

            // Assert
            Assert.AreEqual(questionnaireId, result.RouteValues["questionnaireId"]);
        }

        [Test]
        public void Edit_GET_QuestionDefinitionIdProvided_RequestsSpecifiedQuestionIdFromRepository()
        {
            // Arrange
            var expectedQuestionDefinitionId = QuestionDefinitionId.ChildAge;

            // Act
            _controller.Edit(Guid.NewGuid(), expectedQuestionDefinitionId);

            // Assert
            _baseRepository.Received(1).Find(Arg.Any<Guid>(), Arg.Is(expectedQuestionDefinitionId));
        }

        [Test]
        public void Edit_GET_QuestionInRepository_ReturnsView()
        {
            // Arrange
            var testQuestionDefinition = new IntegerQuestionDefinition { DefaultNextQuestionId = QuestionDefinitionId.ChildAge };
            _questionDefinitionService.GetDefinition(Arg.Any<QuestionDefinitionId>()).Returns(testQuestionDefinition);
            var question = new IntegerQuestion { QuestionDefinitionId = QuestionDefinitionId.ChildAge };
            _baseRepository.Find(Arg.Any<Guid>(), Arg.Any<QuestionDefinitionId>()).Returns(question);

            // Act
            var result = _controller.Edit(Guid.NewGuid(), null) as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void Edit_GET_QuestionInRepository_ProvidesRetrievedQuestionToView()
        {
            // Arrange
            var testQuestionDefinition = new IntegerQuestionDefinition { DefaultNextQuestionId = QuestionDefinitionId.ChildAge };
            _questionDefinitionService.GetDefinition(Arg.Any<QuestionDefinitionId>()).Returns(testQuestionDefinition);
            var question = new IntegerQuestion { QuestionDefinitionId = QuestionDefinitionId.ChildAge };
            _baseRepository.Find(Arg.Any<Guid>(), Arg.Any<QuestionDefinitionId>()).Returns(question);

            // Act
            var result = _controller.Edit(Guid.NewGuid(), null) as ViewResult;

            // Assert
            var model = result.Model as IntegerQuestion;

            Assert.IsNotNull(model);
        }

        [Test]
        public void Edit_GET_QuestionInRepository_AddsQuestionDefinitionToViewBag()
        {
            // Arrange
            var testQuestionDefinition = new IntegerQuestionDefinition { PromptText = "Testing"};
            _questionDefinitionService.GetDefinition(Arg.Any<QuestionDefinitionId>()).Returns(testQuestionDefinition);
            var question = new IntegerQuestion { QuestionDefinitionId = QuestionDefinitionId.ChildAge };
            _baseRepository.Find(Arg.Any<Guid>(), Arg.Any<QuestionDefinitionId>()).Returns(question);

            // Act
            var result = _controller.Edit(Guid.NewGuid(), null) as ViewResult;

            // Assert
            var definition = result.ViewBag.questionDefinition as QuestionDefinitionBase;
            Assert.IsNotNull(definition);
        }

        #endregion

#region Edit() POST

        [Test]
        public void Edit_POST_ValidModel_CallsRepositoryUpdate()
        {
            // Arrange
            var testQuestionDefinition = new IntegerQuestionDefinition { DefaultNextQuestionId = QuestionDefinitionId.ChildAge };
            _questionDefinitionService.GetDefinition(Arg.Any<QuestionDefinitionId>()).Returns(testQuestionDefinition);
            var question = new IntegerQuestion();

            // Act
            _controller.Edit(question);

            // Assert
            _baseRepository.Received(1).Update(Arg.Any<IntegerQuestion>());
        }

        [Test]
        public void Edit_POST_ValidModel_UpdatesModelFromParameter()
        {
            // Arrange
            var testQuestionDefinition = new IntegerQuestionDefinition { DefaultNextQuestionId = QuestionDefinitionId.ChildAge };
            _questionDefinitionService.GetDefinition(Arg.Any<QuestionDefinitionId>()).Returns(testQuestionDefinition);
            var question = new IntegerQuestion();
            question.IntValue = 12345;

            // Act
            _controller.Edit(question);

            // Assert
            _baseRepository.Received().Update(Arg.Is<IntegerQuestion>(x => x.IntValue == 12345));
        }

        [Test]
        public void Edit_POST_ValidModel_CallsRepositorySave()
        {
            // Arrange
            var testQuestionDefinition = new IntegerQuestionDefinition { DefaultNextQuestionId = QuestionDefinitionId.ChildAge };
            _questionDefinitionService.GetDefinition(Arg.Any<QuestionDefinitionId>()).Returns(testQuestionDefinition);
            var question = new IntegerQuestion();

            // Act
            _controller.Edit(question);

            // Assert
            _baseRepository.Received(1).Save();
        }

        [Test]
        public void Edit_POST_ThereIsANextQuestion_RedirectsToEdit()
        {
            // Arrange
            var testQuestionDefinition = new IntegerQuestionDefinition { DefaultNextQuestionId = QuestionDefinitionId.ChildAge };
            _questionDefinitionService.GetDefinition(Arg.Any<QuestionDefinitionId>()).Returns(testQuestionDefinition);

            var question = new IntegerQuestion { QuestionDefinitionId = QuestionDefinitionId.BorrowerAge };

            // Act
            var result = _controller.Edit(question) as RedirectToRouteResult;

            // Assert
            Assert.AreEqual("Edit", result.RouteValues["action"]);
        }

        [Test]
        public void Edit_POST_ThereIsANextQuestion_IncludesCorrectQuestionnaireIdParameter()
        {
            // Arrange
            var testQuestionDefinition = new IntegerQuestionDefinition { DefaultNextQuestionId = QuestionDefinitionId.ChildAge };
            _questionDefinitionService.GetDefinition(Arg.Any<QuestionDefinitionId>()).Returns(testQuestionDefinition);
            var questionnaireId = Guid.NewGuid();
            var question = new IntegerQuestion { QuestionnaireId = questionnaireId };

            // Act
            var result = _controller.Edit(question) as RedirectToRouteResult;

            // Assert
            Assert.AreEqual(questionnaireId, result.RouteValues["questionnaireId"]);
        }

        [Test]
        public void Edit_POST_ThereIsANextQuestion_SpecifiesCorrectNextQuestionId()
        {
            // Arrange
            var testQuestionDefinition = new IntegerQuestionDefinition { DefaultNextQuestionId = QuestionDefinitionId.ChildAge };
            _questionDefinitionService.GetDefinition(Arg.Any<QuestionDefinitionId>()).Returns(testQuestionDefinition);

            var question = new IntegerQuestion { QuestionDefinitionId = QuestionDefinitionId.BorrowerAge };

            // Act
            var result = _controller.Edit(question) as RedirectToRouteResult;

            // Assert
            Assert.AreEqual(QuestionDefinitionId.ChildAge, result.RouteValues["questionDefinitionId"]);
        }

        [Test]
        public void Edit_POST_NoNextQuestion_RedirectToIndexAction()
        {
            // Arrange
            var testQuestionDefinition = new IntegerQuestionDefinition();
            _questionDefinitionService.GetDefinition(Arg.Any<QuestionDefinitionId>()).Returns(testQuestionDefinition);
            var question = new IntegerQuestion { QuestionDefinitionId = QuestionDefinitionId.ChildAge };

            // Act
            var result = _controller.Edit(question) as RedirectToRouteResult;

            // Assert
            Assert.AreEqual("Index", result.RouteValues["action"]);
        }

        [Test]
        public void Edit_POST_NoNextQuestion_RedirectToQuestionnairesController()
        {
            // Arrange
            var testQuestionDefinition = new IntegerQuestionDefinition();
            _questionDefinitionService.GetDefinition(Arg.Any<QuestionDefinitionId>()).Returns(testQuestionDefinition);
            var question = new IntegerQuestion { QuestionDefinitionId = QuestionDefinitionId.ChildAge };

            // Act
            var result = _controller.Edit(question) as RedirectToRouteResult;

            // Assert
            Assert.AreEqual("Questionnaires", result.RouteValues["controller"]);
        }

        [Test]
        public void Edit_POST_InvalidModel_ReturnsView()
        {
            // Arrange
            _controller.ModelState.AddModelError("", "error");

            // Act
            var result = _controller.Edit(new IntegerQuestion()) as ViewResult;

            // Assert
            Assert.AreEqual("", result.ViewName);
        }

        #endregion

#region Other
        /// <summary>
        /// Scans all classes derived from QuestionBase and verifies all public properties are listed in the Bind
        /// attribute. If any properties are omitted, this will cause a bug--only at runtime--where the ommitted property 
        /// value won't be saved to the entity.
        /// </summary>
        [TestCase("Create", TestName = "Create_POST_BindAttribute_IncludesAllQuestionBasePublicProperties")]
        [TestCase("Edit", TestName = "Edit_POST_BindAttribute_IncludesAllQuestionBasePublicProperties")]
        public void BindAttribute(string methodName)
        {
            // Arrange
            var entityBaseType = typeof(EntityBase);
            var questionBaseType = typeof(QuestionBase);
            var assembly = questionBaseType.Assembly;
            var baseAndDerivedTypes = assembly.GetTypes().Where(t => t.IsSubclassOf(questionBaseType)).ToList();

            baseAndDerivedTypes.Add(entityBaseType);
            baseAndDerivedTypes.Add(questionBaseType);

            var publicPropertyNames = new List<string>();

            foreach (var type in baseAndDerivedTypes)
            {
                // Get the public property names
                var typePublicPropertyNames =
                    type.GetTypeInfo().DeclaredProperties.Where(prop => prop.GetMethod.IsPublic).Select(prop => prop.Name);

                // Add them to the list
                publicPropertyNames.AddRange(typePublicPropertyNames);
            }

            // Get the list of property names in the [Bind] attribute
            var controllerType = typeof(QuestionsController);
            var createPostMethod =
                controllerType.GetTypeInfo()
                    .DeclaredMethods.First(m => m.GetCustomAttributes<HttpPostAttribute>().Count() == 1 && m.Name == methodName);
            var bindParameterAttribute = createPostMethod.GetParameters()[0].CustomAttributes.First();
            var propertyNamesStringInBindAttribute = bindParameterAttribute.NamedArguments[0].TypedValue.Value.ToString();
            var propertyNamesInBindAttribute = propertyNamesStringInBindAttribute.Split(',').ToList();

            // Assert
            // Make sure the lists have the same members (without checking for a specific order)
            CollectionAssert.AreEquivalent(publicPropertyNames, propertyNamesInBindAttribute);
        }

        [Test]
        public void Dispose_Invoked_CallsRepositoryDispose()
        {
            // Arrange

            // Act
            _controller.Dispose();

            // Assert
            _baseRepository.Received().Dispose();
        }
#endregion

    }

    // ReSharper restore InconsistentNaming
    // ReSharper restore PossibleNullReferenceException
}