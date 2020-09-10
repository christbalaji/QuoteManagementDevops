using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using QuoteManagement.Controllers;
using QuoteManagement.Interface;
using QuoteManagement.Models;

namespace QuoteManagementTest.Controllers
{
    [TestFixture]
    public class QuoteDetailsControllerTest
    {
        private QuoteDetailsController underTest;
        Mock<IQuoteDetailsService> mockContext;
        List<QuoteDetails> data;

        [SetUp]
        public void Setup()
        {
            data = new List<QuoteDetails>();
            data.Add(new QuoteDetails
            {
                ClientID = 1,
                ClientName = "Balaji",
                DateOfBirth = DateTime.Now,
                EmailID = "balaji.s1@cognizant.com",
                InvestmentAmount = 6000,
                MaturityAmount = 50000,
                MobileNumber = "9791563311",
                PensionPlan = PensionPlans.PensionGold,
                RetirementAge = 79,
                Sex = "Male"
            });
            data.Add(new QuoteDetails
            {
                ClientID = 2,
                ClientName = "Arun",
                DateOfBirth = DateTime.Now,
                EmailID = "arun.s1@cognizant.com",
                InvestmentAmount = 6000,
                MaturityAmount = 50000,
                MobileNumber = "9791563311",
                PensionPlan = PensionPlans.PensionSilver,
                RetirementAge = 79,
                Sex = "Male"
            });

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

            mockContext = new Mock<IQuoteDetailsService>();
            mockContext.Setup(m => m.DeleteQuoteDetails(1)).Returns(Task.FromResult(data.FirstOrDefault()));
            mockContext.Setup(m => m.PostQuoteDetails(quoteDetails)).Returns(Task.FromResult(data.FirstOrDefault()));
            mockContext.Setup(m => m.GetQuoteDetails()).Returns(Task.FromResult(data.AsEnumerable()));
            this.underTest = new QuoteDetailsController(mockContext.Object);
        }

        [Test]
        public async Task GetQuoteDetails()
        {
            var test = await this.underTest.GetQuoteDetails();
            Assert.NotNull(test);
            Assert.Greater(test.Count(), 0);
        }

        [Test]
        public async Task GetQuoteDetailsById()
        {
            mockContext.Setup(m => m.GetQuoteDetails(1)).Returns(Task.FromResult(data.FirstOrDefault()));
            var test = await this.underTest.GetQuoteDetails(1);
            Assert.NotNull(test);
            Assert.AreEqual(test.Value, data[0]);
        }

        [Test]
        public async Task GetQuoteDetailsByIdWithInvalidId()
        {
            mockContext.Setup(m => m.GetQuoteDetails(1)).Returns(Task.FromResult(data.FirstOrDefault()));
            var test = await this.underTest.GetQuoteDetails(-1);
            Assert.NotNull(test);
            Assert.AreEqual(test.Value, null);
        }

        [Test]
        public async Task PutQuoteDetails()
        {
            var quoteDetails = new QuoteDetails
            {
                ClientID = 1,
                ClientName = "Kathir",
                DateOfBirth = DateTime.Now,
                EmailID = "arun.s1@cognizant.com",
                InvestmentAmount = 6000,
                MaturityAmount = 50000,
                MobileNumber = "9791443311",
                PensionPlan = PensionPlans.PensionGold,
                RetirementAge = 79,
                Sex = "Male"
            };
            mockContext.Setup(m => m.PutQuoteDetails(1, quoteDetails)).Returns(Task.FromResult(data.FirstOrDefault()));

            var test = await this.underTest.PutQuoteDetails(1, quoteDetails) as ActionResult<QuoteDetails>;
            Assert.NotNull(test);
            Assert.AreEqual((test.Result as OkObjectResult).StatusCode, 200);
        }

        [Test]
        public async Task PutQuoteDetailsWithNullValue()
        {
            var quoteDetails = new QuoteDetails
            {
                ClientID = 1,
                ClientName = "Kathir",
                DateOfBirth = DateTime.Now,
                EmailID = "arun.s1@cognizant.com",
                InvestmentAmount = 6000,
                MaturityAmount = 50000,
                MobileNumber = "9791443311",
                PensionPlan = PensionPlans.PensionGold,
                RetirementAge = 79,
                Sex = "Male"
            };
            mockContext.Setup(m => m.PutQuoteDetails(1, quoteDetails)).Returns(Task.FromResult(new QuoteDetails()));
            var test = await this.underTest.PutQuoteDetails(0, new QuoteDetails()) as ActionResult<QuoteDetails>;
            Assert.NotNull(test);
            Assert.AreEqual(test.Value, null);
        }

        [Test]
        public async Task PutQuoteDetailsWithNotFound()
        {
            var quoteDetails = new QuoteDetails
            {
                ClientID = 1,
                ClientName = "Kathir",
                DateOfBirth = DateTime.Now,
                EmailID = "arun.s1@cognizant.com",
                InvestmentAmount = 6000,
                MaturityAmount = 50000,
                MobileNumber = "9791443311",
                PensionPlan = PensionPlans.PensionGold,
                RetirementAge = 79,
                Sex = "Male"
            };
            mockContext.Setup(m => m.PutQuoteDetails(1, quoteDetails)).Returns(Task.FromResult(quoteDetails));
            var test = await this.underTest.PutQuoteDetails(0, quoteDetails) as ActionResult<QuoteDetails>;
            Assert.NotNull(test);
            Assert.AreEqual(test.Value, null);
            Assert.AreEqual((test.Result as BadRequestResult).StatusCode, 400);
        }

        [Test]
        public async Task PostQuoteDetails()
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
            var test = await this.underTest.PostQuoteDetails(quoteDetails) as ActionResult<QuoteDetails>;
            Assert.NotNull(test);
            Assert.AreEqual((test.Result as CreatedAtActionResult).StatusCode, 201);
        }

        [Test]
        public async Task PostQuoteDetailsWithNull()
        {
            mockContext.Setup(m => m.PostQuoteDetails(new QuoteDetails())).Returns(Task.FromResult(new QuoteDetails()));
            var test = await this.underTest.PostQuoteDetails(new QuoteDetails()) as ActionResult<QuoteDetails>;
            Assert.NotNull(test);
            Assert.AreEqual(test.Value, null);
        }

        [Test]
        public async Task DeleteQuoteDetails()
        {
            mockContext.Setup(m => m.GetQuoteDetails(1)).Returns(Task.FromResult(data.FirstOrDefault()));
            var test = await this.underTest.DeleteQuoteDetails(1);
            Assert.NotNull(test);
            Assert.AreEqual(test.Value, data[0]);
        }

        [Test]
        public async Task DeleteQuoteDetailsWithNotFound()
        {
            var test = await this.underTest.DeleteQuoteDetails(1);
            Assert.NotNull(test);
            Assert.AreEqual((test.Result as NotFoundResult).StatusCode, 404);
        }
    }
}
