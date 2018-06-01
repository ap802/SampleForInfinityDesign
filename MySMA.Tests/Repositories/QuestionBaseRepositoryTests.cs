using System;
using NUnit.Framework;
using MySMA.Models;
using MySMA.Repositories;
using MySMA.Tests.Mocks;

namespace MySMA.Tests.Repositories
{
    class QuestionBaseRepositoryTests
    {
        private FakeAppContext _fakeDbContext;
        private QuestionBaseRepository _repository;

        [SetUp]
        public void SetUp()
        {
            // Configure objects used in every test
            _fakeDbContext = new FakeAppContext();
            _repository = new QuestionBaseRepository(_fakeDbContext);
        }

        [Test]
        public void Find_EntityExistsWithSpecifiedQuestionnaireIdAndQuestionId_ReturnsEntity()
        {
            // Arrange
            var question = new IntegerQuestion{QuestionnaireId = Guid.NewGuid() };
            _repository.Insert(question);

            // Act
            var result = _repository.Find(question.QuestionnaireId, question.QuestionDefinitionId );

            // Assert
            Assert.AreEqual(result.Id, question.Id);
        }

        [Test]
        public void Find_EntityExistsWithSpecifiedQuestionnaireIdButDifferentQuestionId_ReturnsNull()
        {
            // Arrange
            QuestionBase question = new IntegerQuestion();
            _repository.Insert(question);

            // Act
            var result = _repository.Find(question.Id, QuestionDefinitionId.MaritalStatus);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void Find_EntityExistsWithDifferentQuestionnaireIdAndSpecifiedQuestionId_ReturnsNull()
        {
            // Arrange
            QuestionBase question = new IntegerQuestion();
            _repository.Insert(question);

            // Act
            var result = _repository.Find(Guid.NewGuid(), question.QuestionDefinitionId);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void Find_NoEntitiesInDbSet_ReturnsNull()
        {
            // Arrange

            // Act
            var result = _repository.Find(Guid.NewGuid(), QuestionDefinitionId.MaritalStatus);

            // Assert
            Assert.IsNull(result);
        }
    }
}
