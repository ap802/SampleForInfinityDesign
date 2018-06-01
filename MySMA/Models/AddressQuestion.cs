using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MySMA.Properties;

namespace MySMA.Models
{
    public class AddressQuestion : SingleSelectQuestionBase
    {
        [Display(Name = "Question_DisplayName_Street", ResourceType = typeof(Resources))]
        public string StreetValue { get; set; }
        [Display(Name = "Question_DisplayName_City", ResourceType = typeof(Resources))]
        public string CityValue { get; set; }
        [Display(Name = "Question_DisplayName_State", ResourceType = typeof(Resources))]
        public string StateValue { get; set; }
        [Display(Name = "Question_DisplayName_Zip", ResourceType = typeof(Resources))]
        public string ZipValue { get; set; }
    }
}