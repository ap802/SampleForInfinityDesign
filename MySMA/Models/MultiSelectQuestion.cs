using System.Collections.Generic;

namespace MySMA.Models
{
    public class MultiSelectQuestion : QuestionBase
    {
        public IEnumerable<int> SelectedAnswers { get; set; }
    }
}