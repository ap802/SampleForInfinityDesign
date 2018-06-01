using MySMA.Models;

namespace MySMA.Services
{
    public interface IQuestionDefinitionService
    {
        QuestionDefinitionBase GetDefinition(QuestionDefinitionId id);
        QuestionDefinitionId FirstDefinitionId { get; }
        QuestionDefinitionBase GetFirstDefinition();
    }
}