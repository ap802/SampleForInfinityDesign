using System.ComponentModel.DataAnnotations;
using MySMA.Properties;

namespace MySMA.Models
{
    public class EmployerQuestion : MonthYearQuestion
    {
        [Display(Name = "Question_DisplayName_EmployerName", ResourceType = typeof(Resources))]
        public string EmployerNameValue { get; set; }
        [Display(Name = "Question_DisplayName_PositionTitle", ResourceType = typeof(Resources))]
        public string PositionTitleValue { get; set; }
        [Display(Name = "Question_DisplayName_Address", ResourceType = typeof(Resources))]
        public string AddressValue { get; set; }
    }
}