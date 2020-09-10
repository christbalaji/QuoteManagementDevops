using NUnit.Framework;
using QuoteManagement.Models;
using System;

namespace QuoteManagementTest
{
    [TestFixture]
    public class QuoteDetailsTest
    {
        QuoteDetails _quoteDetails;

        [SetUp]
        public void TextFixtureSetup()
        {
            _quoteDetails = new QuoteDetails();
        }

        [Test]
        public void ClientIDTest()
        {
            Assert.IsInstanceOf(typeof(int), _quoteDetails.ClientID);
            _quoteDetails.ClientID = 1;
            Assert.IsNotNull(_quoteDetails.ClientID);
        }

        [Test]
        public void ClientNameTest()
        {
            Assert.IsNull(_quoteDetails.ClientName);
            _quoteDetails.ClientName = "test";
            Assert.IsNotNull(_quoteDetails.ClientName);
        }

        [Test]
        public void SexTest()
        {
            Assert.IsNull(_quoteDetails.Sex);
            _quoteDetails.Sex = "test";
            Assert.IsNotNull(_quoteDetails.Sex);
        }

        [Test]
        public void QuoteDateTest()
        {
            Assert.IsInstanceOf(typeof(DateTime), _quoteDetails.QuoteDate);
            _quoteDetails.QuoteDate = DateTime.Now;
            Assert.IsNotNull(_quoteDetails.QuoteDate);
        }

        [Test]
        public void DateOfBirthTest()
        {
            Assert.IsInstanceOf(typeof(DateTime), _quoteDetails.DateOfBirth);
            _quoteDetails.DateOfBirth = DateTime.Now;
            Assert.IsNotNull(_quoteDetails.DateOfBirth);
        }

        [Test]
        public void EmailIDTest()
        {
            Assert.IsNull(_quoteDetails.EmailID);
            _quoteDetails.EmailID = "test";
            Assert.IsNotNull(_quoteDetails.EmailID);
        }

        [Test]
        public void MobileNumberTest()
        {
            Assert.IsNull(_quoteDetails.MobileNumber);
            _quoteDetails.MobileNumber = "9791564443";
            Assert.IsNotNull(_quoteDetails.MobileNumber);
        }

        [Test]
        public void InvestmentAmountTest()
        {
            Assert.IsInstanceOf(typeof(decimal), _quoteDetails.InvestmentAmount);
            _quoteDetails.InvestmentAmount = 6789;
            Assert.IsNotNull(_quoteDetails.InvestmentAmount);
        }

        [Test]
        public void RetirementAgeTest()
        {
            Assert.IsInstanceOf(typeof(int), _quoteDetails.RetirementAge);
            _quoteDetails.RetirementAge = 67;
            Assert.IsNotNull(_quoteDetails.RetirementAge);
        }

        [Test]
        public void PensionPlanTest()
        {
            Assert.IsInstanceOf(typeof(PensionPlans), _quoteDetails.PensionPlan);
            _quoteDetails.PensionPlan = PensionPlans.PensionPlatinum;
            Assert.IsNotNull(_quoteDetails.PensionPlan);
        }

        [Test]
        public void MaturityAmountTest()
        {
            Assert.IsInstanceOf(typeof(decimal), _quoteDetails.MaturityAmount);
            _quoteDetails.MaturityAmount = 16789;
            Assert.IsNotNull(_quoteDetails.MaturityAmount);
        }
    }
}
