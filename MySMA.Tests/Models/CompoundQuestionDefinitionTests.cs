using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySMA.Models;
using NUnit.Core;
using NUnit.Framework;

namespace MySMA.Tests.Models
{
    class CompoundQuestionDefinitionTests
    {

        [Test]
        public void CreateQuestion_Invoked_ReturnsAddressQuestion()
        {
            // Arrange
            var definitionType = new AddressQuestionDefinition();

            // Act
            var question = definitionType.CreateQuestion();

            // Assert
            Assert.IsInstanceOf<AddressQuestion>(question);
        }

        [Test]
        public void CreateQuestion_Invoked_ReturnsDebtDetailsQuestion()
        {
            // Arrange
            var definitionType = new DebtDetailsQuestionDefinition();

            // Act
            var question = definitionType.CreateQuestion();

            // Assert
            Assert.IsInstanceOf<DebtDetailsQuestion>(question);
        }

        [Test]
        public void CreateQuestion_Invoked_ReturnsMonthYearQuestion()
        {
            // Arrange
            var definitionType = new MonthYearQuestionDefinition();

            // Act
            var question = definitionType.CreateQuestion();

            // Assert
            Assert.IsInstanceOf<MonthYearQuestion>(question);
        }

        [Test]
        public void CreateQuestion_Invoked_ReturnsMonthYearDurationQuestion()
        {
            // Arrange
            var definitionType = new MonthYearDurationQuestionDefinition();

            // Act
            var question = definitionType.CreateQuestion();

            // Assert               
            Assert.IsInstanceOf<MonthYearDurationQuestion>(question);
        }

        [Test]
        public void CreateQuestion_Invoked_ReturnsNameEmailPhoneQuestion()
        {
            // Arrange
            var definitionType = new NameEmailPhoneQuestionDefinition();

            // Act
            var question = definitionType.CreateQuestion();

            // Assert
            Assert.IsInstanceOf<NameEmailPhoneQuestion>(question);
        }

        [Test]
        public void CreateQuestion_Invoked_ReturnsEmployerQuestion()
        {
            // Arrange
            var definitionType = new EmployerQuestionDefinition();

            // Act
            var question = definitionType.CreateQuestion();

            // Assert
            Assert.IsInstanceOf<EmployerQuestion>(question);
        }
    }
}
