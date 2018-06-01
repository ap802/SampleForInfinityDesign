using System;
using System.ComponentModel.DataAnnotations;
using MySMA.Properties;

namespace MySMA.Models
{
    public class MonthYearQuestion : QuestionBase
    {
        [Display(Name = "Question_DisplayName_Month", ResourceType = typeof(Resources))]
        public string MonthValue { get; set; }

        [Display(Name = "Question_DisplayName_Year", ResourceType = typeof(Resources))]
        public string YearValue { get; set; }
    }
}