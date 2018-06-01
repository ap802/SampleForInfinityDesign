using System.ComponentModel;

namespace MySMA.Models
{
    public class Questionnaire : EntityBase
    {
        public Questionnaire()
        {
            
        }

        [DisplayName("First Name")]
        public string BorrowerFirstName { get; set; }

        [DisplayName("Middle Initial")]
        public string BorrowerMiddleInitial { get; set; }

        [DisplayName("Last Name")]
        public string BorrowerLastName { get; set; }

        [DisplayName("Suffix")]
        public string BorrowerSuffix { get; set; }

        [DisplayName("Email Address")]
        public string BorrowerEmail { get; set; }

        [DisplayName("Home Phone Number")]
        public string BorrowerHomePhone { get; set; }

        [DisplayName("Cell Phone Number")]
        public string BorrowerCellPhone { get; set; }
    }
}