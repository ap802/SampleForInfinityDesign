using NUnit.Framework;
using MySMA.Models;


namespace MySMA.Tests.Models
{
    class StringQuestionDefinitionTests
    {
        [Test]
        public void CreateQuestion_Invoked_ReturnsStringQuestion()
        {
            // Arrange
            var definitionType = new StringQuestionDefinition();

            // Act
            var question = definitionType.CreateQuestion();

            // Assert
            Assert.IsInstanceOf<StringQuestion>(question);
        }
    }
}
