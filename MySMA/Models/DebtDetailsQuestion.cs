using System.ComponentModel.DataAnnotations;
using MySMA.Properties;

namespace MySMA.Models
{
    public class DebtDetailsQuestion : QuestionBase
    {
        [Display(Name = "Question_DisplayName_Debtor", ResourceType = typeof(Resources))]
        public string DebtorValue { get; set; }

        [Display(Name = "Question_DisplayName_AmountOwed", ResourceType = typeof(Resources))]
        public decimal? AmountOwedValue { get; set; }

        [Display(Name = "Question_DisplayName_MonthlyPayment", ResourceType = typeof(Resources))]
        public decimal? MonthlyPaymentValue { get; set; }
    }
}