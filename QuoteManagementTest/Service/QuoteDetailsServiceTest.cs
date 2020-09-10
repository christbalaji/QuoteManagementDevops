using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using QuoteManagement.Data;
using QuoteManagement.Models;
using QuoteManagement.Service;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuoteManagementTest.Service
{
    [TestFixture]
    public class QuoteDetailsServiceTest
    {
        private QuoteDetailsService underTest;
        Mock<QuoteManagementContext> mockContext;
        IList<QuoteDetails> data;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<QuoteManagementContext>().Options;
            mockContext = new Mock<QuoteManagementContext>(options);
            data = new List<QuoteDetails>();
            data.Add(new QuoteDetails
            {
                ClientID = 1,
                ClientName = "Balaji",
                DateOfBirth = DateTime.Now,
                EmailID = "balaji.s1@cognizant.com",
                InvestmentAmount = 6000,
                MaturityAmount = 50000,
                MobileNumber = "9791564443",
                PensionPlan = PensionPlans.PensionSilver,
                RetirementAge = 79,
                Sex = "Male"
            });
            data.Add(new QuoteDetails
            {
                ClientID = 2,
                ClientName = "Arun",
                DateOfBirth = DateTime.Now,
                EmailID = "balaji.s1@cognizant.com",
                InvestmentAmount = 6000,
                MaturityAmount = 50000,
                MobileNumber = "9791564443",
                PensionPlan = PensionPlans.PensionSilver,
                RetirementAge = 79,
                Sex = "Male"
            });

            var mockDbSet = new Mock<DbSet<QuoteDetails>>();
            var queryable = data.AsQueryable();

            mockDbSet.As<IQueryable<QuoteDetails>>().Setup(m => m.Provider).Returns(queryable.Provider);
            mockDbSet.As<IQueryable<QuoteDetails>>().Setup(m => m.Expression).Returns(queryable.Expression);
            mockDbSet.As<IQueryable<QuoteDetails>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            mockDbSet.As<IQueryable<QuoteDetails>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());

            mockDbSet.Setup(m => m.Add(It.IsAny<QuoteDetails>())).Callback<QuoteDetails>((s) => data.Add(s));

            //mockContext.Setup(m => m.QuoteDetails).Returns(mockDbSet.Object);

            this.underTest = new QuoteDetailsService(mockContext.Object);
        }

        private List<QuoteDetails> GetCompanyList()
        {
            return data.ToList();
        }

        [Test]
        public void DeleteQuoteDetails()
        {
            var test = this.underTest.DeleteQuoteDetails(1);
            Assert.NotNull(test);
            Assert.Pass();
        }

        [Test]
        public void GetQuoteDetails()
        {
            var test = this.underTest.GetQuoteDetails();
            Assert.NotNull(test);
            Assert.Pass();
        }

        [Test]
        public void GetQuoteDetailsById()
        {
            var test = this.underTest.GetQuoteDetails(1);
            Assert.NotNull(test);
            Assert.Pass();
        }

        [Test]
        public void PostQuoteDetails()
        {
            var quoteDetails = new QuoteDetails
            {
                ClientID = 1,
                ClientName = "Kathir",
                DateOfBirth = DateTime.Now,
                EmailID = "arun.s1@cognizant.com",
                InvestmentAmount = 6000,
                MaturityAmount = 50000,
                MobileNumber = "9791564443",
                PensionPlan = PensionPlans.PensionPlatinum,
                RetirementAge = 79,
                Sex = "Male"
            };
            var test = this.underTest.PostQuoteDetails(quoteDetails);
            Assert.NotNull(test);
            Assert.Pass();
        }

        [Test]
        public void PutQuoteDetails()
        {
            var quoteDetails = new QuoteDetails
            {
                ClientID = 1,
                ClientName = "Kathir",
                DateOfBirth = DateTime.Now,
                EmailID = "arun.s1@cognizant.com",
                InvestmentAmount = 6000,
                MaturityAmount = 50000,
                MobileNumber = "9791564443",
                PensionPlan = PensionPlans.PensionGold,
                RetirementAge = 79,
                Sex = "Male"
            };
            var test = this.underTest.PutQuoteDetails(1, quoteDetails);
            Assert.NotNull(test);
            Assert.Pass();
        }
    }
}
