namespace MySMA.Models
{
    public class CurrencyQuestionDefinition : QuestionDefinitionBase
    {
        protected override QuestionBase CreateQuestionOfCorrectType()
        {
            return new CurrencyQuestion();
        }
    }
}