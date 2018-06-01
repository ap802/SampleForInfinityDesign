using System;
using System.Collections.Generic;
using System.Linq;

namespace MySMA.Models
{
    public class MonthYearQuestionDefinition : QuestionDefinitionBase
    {
        public List<PossibleAnswer> MonthList { get; set; }
        public List<string> YearList {
            get
            {
                return GetYearList();
            }
        }

        public int Years { get; set; }

        private List<string> GetYearList()
        {
            var res = new List<string>();
            if (Years > 0)
            {
                res = Enumerable.Range(DateTime.Today.Year, Years).ToList().ConvertAll(i => i.ToString());
            }
            else
            {
                res = Enumerable.Range(DateTime.Today.Year + Years + 1, Math.Abs(Years)).Reverse().ToList().ConvertAll(i => i.ToString());
            }

            res.Insert(0, string.Empty);

            return res;
        }

        protected override QuestionBase CreateQuestionOfCorrectType()
        {
            return new MonthYearQuestion();
        }
    }
}