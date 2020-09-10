using QuoteManagement.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace QuoteManagement.Validation
{
    [Serializable]
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class quoteDataValidationAttribute : ValidationAttribute
    {
        public static ValidationResult HasValidMaturityAmountValidation(QuoteDetails quoteDetails)
        {
            if (quoteDetails.PensionPlan == PensionPlans.PensionSilver)
            {
                if (quoteDetails.RetirementAge >= 65 && quoteDetails.InvestmentAmount >= 100000)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Pension Silver should have minimum retirement age is 65 and investment amount is 100000");
                }
            }
            else if (quoteDetails.PensionPlan == PensionPlans.PensionGold)
            {
                if (quoteDetails.RetirementAge >= 63 && quoteDetails.InvestmentAmount >= 300000)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Pension Gold should have minimum retirement age is 63 and investment amount is 300000");
                }
            }
            else if (quoteDetails.PensionPlan == PensionPlans.PensionPlatinum)
            {
                if (quoteDetails.RetirementAge >= 60 && quoteDetails.InvestmentAmount >= 500000)
                {
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Pension Silver should have minimum retirement age is 60 and investment amount is 500000");
                }
            }
            return ValidationResult.Success;
        }
    }
}
