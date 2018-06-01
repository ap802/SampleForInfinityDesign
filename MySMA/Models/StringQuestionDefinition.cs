namespace MySMA.Models
{
    public class StringQuestionDefinition : QuestionDefinitionBase
    {
        protected override QuestionBase CreateQuestionOfCorrectType()
        {
            return new StringQuestion();
        }
    }
}