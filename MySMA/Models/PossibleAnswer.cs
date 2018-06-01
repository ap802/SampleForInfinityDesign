namespace MySMA.Models
{
    public class PossibleAnswer
    {
        public string PromptText { get; set; }
        public int AnswerId { get; set; }
        public QuestionDefinitionId? NextQuestion { get; set; }
    }
}