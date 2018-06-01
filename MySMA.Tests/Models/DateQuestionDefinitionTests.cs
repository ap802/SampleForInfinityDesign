using NUnit.Framework;
using MySMA.Models;

namespace MySMA.Tests.Models
{
    class DateQuestionDefinitionTests
    {
        [Test]
        public void CreateQuestion_Invoked_ReturnsDateQuestion()
        {
            // Arrange
            var definitionType = new DateQuestionDefinition();

            // Act
            var question = definitionType.CreateQuestion();

            // Assert
            Assert.IsInstanceOf<DateQuestion>(question);
        }
    }
}
