using System.Collections.Generic;

namespace MySMA.Models
{
    public class AddressQuestionDefinition : QuestionDefinitionBase
    {
        public List<string> StateList { get; set; }

        protected override QuestionBase CreateQuestionOfCorrectType()
        {
            return new AddressQuestion();
        }

    }
}