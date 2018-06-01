namespace MySMA.Models
{
    public class NameEmailPhoneQuestionDefinition : QuestionDefinitionBase
    {
        protected override QuestionBase CreateQuestionOfCorrectType()
        {
            return new NameEmailPhoneQuestion();
        }
    }
}