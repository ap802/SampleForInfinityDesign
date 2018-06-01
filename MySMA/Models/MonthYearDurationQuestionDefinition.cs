using System;
using System.Collections.Generic;
using System.Linq;

namespace MySMA.Models
{
    public class MonthYearDurationQuestionDefinition : QuestionDefinitionBase
    {
        public List<string> MonthDurationList { get; }
        public List<string> YearDurationList { get; }

        public MonthYearDurationQuestionDefinition()
        {

            MonthDurationList = new List<string>();
            MonthDurationList = Enumerable.Range(0, 12).ToList().ConvertAll(i => i.ToString());
            MonthDurationList.Insert(0, string.Empty);

            YearDurationList = new List<string>();
            YearDurationList = Enumerable.Range(0, 101).ToList().ConvertAll(i => i.ToString());
            YearDurationList.Insert(0, string.Empty);
        }

        protected override QuestionBase CreateQuestionOfCorrectType()
        {
            return new MonthYearDurationQuestion();
        }
    }
}