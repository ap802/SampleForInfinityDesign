using NUnit.Framework;
using MySMA.Models;

namespace MySMA.Tests.Models
{
    class IntegerQuestionDefinitionTests
    {
        [Test]
        public void CreateQuestion_Invoked_ReturnsIntegerQuestion()
        {
            // Arrange
            var definitionType = new IntegerQuestionDefinition();

            // Act
            var question = definitionType.CreateQuestion();

            // Assert
            Assert.IsInstanceOf<IntegerQuestion>(question);
        }
    }
}
