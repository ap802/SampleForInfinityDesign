namespace MySMA.Models
{
    public class DebtDetailsQuestionDefinition : QuestionDefinitionBase
    {
        protected override QuestionBase CreateQuestionOfCorrectType()
        {
            return new DebtDetailsQuestion();
        }
    }
}