using NUnit.Framework;
using MySMA.Models;

namespace MySMA.Tests.Models
{
    class RadioButtonQuestionDefinitionTests
    {
        [Test]
        public void CreateQuestion_Invoked_ReturnsSingleSelectQuestion()
        {
            // Arrange
            var definitionType = new RadioButtonQuestionDefinition();

            // Act
            var question = definitionType.CreateQuestion();

            // Assert
            Assert.IsInstanceOf<RadioButtonQuestion>(question);
        }
    }
}
