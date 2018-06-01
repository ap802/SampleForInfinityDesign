using NUnit.Framework;
using MySMA.Models;

namespace MySMA.Tests.Models
{
    class MultiSelectQuestionDefinitionTests
    {
        [Test]
        public void CreateQuestion_Invoked_ReturnsMultiSelectQuestion()
        {
            // Arrange
            var definitionType = new MultiSelectQuestionDefinition();

            // Act
            var question = definitionType.CreateQuestion();

            // Assert
            Assert.IsInstanceOf<MultiSelectQuestion>(question);
        }
    }
}
