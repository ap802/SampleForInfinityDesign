using System.Collections.Generic;

namespace MySMA.Models
{
    public class SingleSelectQuestionDefinitionBase : QuestionDefinitionBase
    {
        protected override QuestionBase CreateQuestionOfCorrectType()
        {
            return new SingleSelectQuestionBase();
        }

        public override QuestionDefinitionId? GetNextQuestionId(QuestionBase question)
        {
            var q = question as SingleSelectQuestionBase;
            if (q == null) return base.GetNextQuestionId(question);

            var selectedAbswer = PossibleAnswers.Find(a => a.AnswerId == q.SelectedAnswer);

            QuestionDefinitionId? result = null;
            if (selectedAbswer != null)
                result =  selectedAbswer.NextQuestion;

            return result ?? base.GetNextQuestionId(question);
        }

        public List<PossibleAnswer> PossibleAnswers { get; set; }
    }
}