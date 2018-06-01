using System;
using System.ComponentModel.DataAnnotations;
using MySMA.Properties;

namespace MySMA.Models
{
    public class MonthYearDurationQuestion : QuestionBase
    {
        [Display(Name = "Question_DisplayName_Month", ResourceType = typeof(Resources))]
        public string MonthDurationValue { get; set; }

        [Display(Name = "Question_DisplayName_Year", ResourceType = typeof(Resources))]
        public string YearDurationValue { get; set; }
    }
}