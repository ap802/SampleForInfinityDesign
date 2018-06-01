using System.ComponentModel.DataAnnotations;
using MySMA.Properties;

namespace MySMA.Models
{
    public class NameEmailPhoneQuestion : QuestionBase
    {
        [Display(Name = "Question_DisplayName_ContactName", ResourceType = typeof(Resources))]
        public string NameValue { get; set; }

        [Display(Name = "Question_DisplayName_EmailAddress", ResourceType = typeof(Resources))]
        public string EmailValue { get; set; }

        [Display(Name = "Question_DisplayName_PhoneNumber", ResourceType = typeof(Resources))]
        public string PhoneValue { get; set; }
    }
}