using System;
using NUnit.Framework;
using MySMA.Models;

namespace MySMA.Tests.Models
{
    // ReSharper disable InconsistentNaming
    // ReSharper disable PossibleNullReferenceException

    /// <summary>
    /// Note: This class uses one concrete type to test base class functionality, since the base class is abstract.
    /// </summary>
    [TestFixture]
    public class QuestionDefinitionBaseTests
    {
        private IntegerQuestionDefinition _questionDefinition;

        [SetUp]
        public void SetUp()
        {
            _questionDefinition = new IntegerQuestionDefinition();
        }

        [Test]
        public void CreateQuestion_Invoked_SetsQuestionDefinitionId()
        {
            // Arrange
            _questionDefinition.Id = QuestionDefinitionId.ChildAge;

            // Act
            var question = _questionDefinition.CreateQuestion();

            // Assert
            Assert.AreEqual(QuestionDefinitionId.ChildAge, question.QuestionDefinitionId);
        }
    }

    // ReSharper restore InconsistentNaming
    // ReSharper restore PossibleNullReferenceException
}