namespace MySMA.Models
{
    public class DropDownQuestionDefinition: SingleSelectQuestionDefinitionBase
    {
        protected override QuestionBase CreateQuestionOfCorrectType()
        {
            return new DropDownQuestion();
        }
    }
}