using System.Collections.Generic;
using MySMA.Models;
using NUnit.Framework;

namespace MySMA.Tests.Models
{
    [TestFixture]
    class SingleSelectQuestionDefinitionBaseTests
    {
        private SingleSelectQuestionDefinitionBase _questionDefinition;

        [SetUp]
        public void SetUp()
        {
            _questionDefinition = new SingleSelectQuestionDefinitionBase
            {DefaultNextQuestionId = QuestionDefinitionId.BorrowerAge};
        }

        [Test]
        public void GetNextQuestionId_GetWrongquestionType_ReturnBaseValue()
        {
            // Arrange            

            // Act
            var res = _questionDefinition.GetNextQuestionId(new CurrencyQuestion());

            // Assert
            Assert.AreEqual(QuestionDefinitionId.BorrowerAge, res);
        }

        [Test]
        public void GetNextQuestionId_SelectedAnswerContainsNextQuestionId_ReturnIdFromAnswer()
        {
            // Arrange            
            _questionDefinition.PossibleAnswers = new List<PossibleAnswer>
            {
                new PossibleAnswer
                {AnswerId = 0, NextQuestion = QuestionDefinitionId.AuthorizeCreditReport}
            };

            // Act
            var res = _questionDefinition.GetNextQuestionId(new SingleSelectQuestionBase {SelectedAnswer = 0});

            // Assert
            Assert.AreEqual(QuestionDefinitionId.AuthorizeCreditReport, res);
        }

        [Test]
        public void GetNextQuestionId_SelectedAnswerNotContainsNextQuestionId_ReturnBaseValue()
        {
            // Arrange            
            _questionDefinition.PossibleAnswers = new List<PossibleAnswer>
            {
                new PossibleAnswer
                {AnswerId = 0}
            };

            // Act
            var res = _questionDefinition.GetNextQuestionId(new SingleSelectQuestionBase { SelectedAnswer = 0 });

            // Assert
            Assert.AreEqual(QuestionDefinitionId.BorrowerAge, res);
        }
    }
}
