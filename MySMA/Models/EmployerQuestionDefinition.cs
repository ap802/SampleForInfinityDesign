namespace MySMA.Models
{
    public class EmployerQuestionDefinition : MonthYearQuestionDefinition
    {
        protected override QuestionBase CreateQuestionOfCorrectType()
        {
            return new EmployerQuestion();
        }
    }
}