namespace MySMA.Models
{
    public class IntegerQuestionDefinition : QuestionDefinitionBase
    {
        protected override QuestionBase CreateQuestionOfCorrectType()
        {
            return new IntegerQuestion();
        }
    }
}