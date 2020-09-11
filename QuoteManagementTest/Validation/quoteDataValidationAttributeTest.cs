using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using QuoteManagement.Data;
using QuoteManagement.Models;
using QuoteManagement.Service;
using QuoteManagement.Validation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuoteManagementTest.Validation
{
    [TestFixture]
    public class quoteDataValidationAttributeTest
    {

        [SetUp]
        public void Setup()
        {
         
        }

        [Test]
        public void HasValidMaturityAmountValidationForPensionGold()
        {
            var quoteDetails = new QuoteDetails
            {
                ClientID = 1,
                ClientName = "Kathir",
                DateOfBirth = DateTime.Now,
                EmailID = "arun.s1@cognizant.com",
                InvestmentAmount = 6000,
                MaturityAmount = 50000,
                MobileNumber = "9791563311",
                PensionPlan = PensionPlans.PensionGold,
                RetirementAge = 79,
                Sex = "Male"
            };
            var test = quoteDataValidationAttribute.HasValidMaturityAmountValidation(quoteDetails);
            Assert.NotNull(test);
            Assert.AreEqual(test.ErrorMessage, "Pension Gold should have minimum retirement age is 63 and investment amount is 300000");
        }

        [Test]
        public void HasValidMaturityAmountValidationForPensionSilver()
        {
            var quoteDetails = new QuoteDetails
            {
                ClientID = 1,
                ClientName = "Kathir",
                DateOfBirth = DateTime.Now,
                EmailID = "arun.s1@cognizant.com",
                InvestmentAmount = 6000,
                MaturityAmount = 50000,
                MobileNumber = "9791563311",
                PensionPlan = PensionPlans.PensionSilver,
                RetirementAge = 79,
                Sex = "Male"
            };
            var test = quoteDataValidationAttribute.HasValidMaturityAmountValidation(quoteDetails);
            Assert.NotNull(test);
            Assert.AreEqual(test.ErrorMessage, "Pension Silver should have minimum retirement age is 65 and investment amount is 100000");
        }

        [Test]
        public void HasValidMaturityAmountValidationForPensionPlatinum()
        {
            var quoteDetails = new QuoteDetails
            {
                ClientID = 1,
                ClientName = "Kathir",
                DateOfBirth = DateTime.Now,
                EmailID = "arun.s1@cognizant.com",
                InvestmentAmount = 6000,
                MaturityAmount = 50000,
                MobileNumber = "9791563311",
                PensionPlan = PensionPlans.PensionPlatinum,
                RetirementAge = 79,
                Sex = "Male"
            };
            var test = quoteDataValidationAttribute.HasValidMaturityAmountValidation(quoteDetails);
            Assert.NotNull(test);
            Assert.AreEqual(test.ErrorMessage, "Pension Platinum should have minimum retirement age is 60 and investment amount is 500000");
        }
    }
}
