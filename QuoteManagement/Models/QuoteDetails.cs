using QuoteManagement.Validation;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace QuoteManagement.Models
{
    public class QuoteDetails
    {
        [Key]
        public int ClientID { get; set; }
        [Display(Name = "Client Name"), Required(ErrorMessage = "Please enter Client Name")]
        public string ClientName { get; set; }
        [Display(Name = "Client Sex"), Required(ErrorMessage = "Please enter Client Sex")]
        public string Sex { get; set; }
        [Display(Name = "Date Of Birth"), Required(ErrorMessage = "Please enter Date Of Birth")]
        public DateTime DateOfBirth { get; set; }

        private DateTime quoteDate = DateTime.Now.ToUniversalTime();
        [Display(Name = "Quote Date")]
        public DateTime QuoteDate { get { return quoteDate; } set { quoteDate = value; } }
        [Display(Name = "Email"), Required(ErrorMessage = "Please enter Email ID"), DataType(DataType.EmailAddress), EmailAddress]
        public string EmailID { get; set; }
        [Display(Name = "Mobile Number"), RegularExpression("([0-9]+)", ErrorMessage = "Please enter valid number"), MaxLength(10), MinLength(10, ErrorMessage = "Please enter 10 digits Mobile number"), Required(ErrorMessage = "Please enter Mobile Number")]
        public string MobileNumber { get; set; }
        [Display(Name = "Investment Amount"), Column(TypeName = "decimal(18,2)")]
        public decimal InvestmentAmount { get; set; }
        [Display(Name = "Retirement Age"), Range(60, 75, ErrorMessage = "Retirement age must between 60 to 75"), Required(ErrorMessage = "Please enter Retirement Age")]
        public int RetirementAge { get; set; }
        [Display(Name = "Pension Plan"), EnumDataType(typeof(PensionPlans)), Required(ErrorMessage = "Please enter Pension Plan"), Range(1, 3, ErrorMessage = "Please enter correct pension value. /n 1. Pension Silver, /n 2. Pension Gold, /n 3. Pension Platinum.")]
        public PensionPlans PensionPlan { get; set; }
        [Display(Name = "Maturity Amount"), Column(TypeName = "decimal(18,2)")]
        public decimal MaturityAmount { get; set; }
    }

    public enum PensionPlans
    {
        PensionSilver = 1,
        PensionGold = 2,
        PensionPlatinum = 3,
    }
}
