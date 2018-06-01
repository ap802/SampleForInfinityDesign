using System;
using MySMA.Models;

namespace MySMA.Repositories
{
    public interface IQuestionBaseRepository : IRepository<QuestionBase>
    {
        QuestionBase Find(Guid questionnaireId, QuestionDefinitionId questionDefinitionId);
    }
}