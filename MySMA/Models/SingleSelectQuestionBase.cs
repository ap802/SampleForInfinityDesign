namespace MySMA.Models
{
    public class SingleSelectQuestionBase : QuestionBase
    {
        public SingleSelectQuestionBase()
        {
            // Default to no selected answer.
            SelectedAnswer = -1;
        }

        public int SelectedAnswer { get; set; }
    }
}