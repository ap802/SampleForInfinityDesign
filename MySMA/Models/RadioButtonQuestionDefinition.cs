namespace MySMA.Models
{
    public class RadioButtonQuestionDefinition: SingleSelectQuestionDefinitionBase
    {
        protected override QuestionBase CreateQuestionOfCorrectType()
        {
            return new RadioButtonQuestion();
        }
    }
}