using System.Collections.Generic;

namespace MySMA.Models
{
    public class MultiSelectQuestionDefinition : QuestionDefinitionBase
    {
        protected override QuestionBase CreateQuestionOfCorrectType()
        {
            return new MultiSelectQuestion();
        }

        public List<PossibleAnswer> PossibleAnswers { get; set; }
    }
}