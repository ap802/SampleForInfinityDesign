namespace MySMA.Models
{
    public class DateQuestionDefinition : QuestionDefinitionBase
    {
        protected override QuestionBase CreateQuestionOfCorrectType()
        {
            return new DateQuestion();
        }
    }
}