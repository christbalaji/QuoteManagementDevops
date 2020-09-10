using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using QuoteManagement.Data;
using QuoteManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QuoteManagementTest.Data
{
    [TestFixture]
    public class MicroServiceContextTest
    {
        QuoteManagementContext _microServiceContext;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptions<QuoteManagementContext>();
            _microServiceContext = new QuoteManagementContext(options);
            _microServiceContext.QuoteDetails = null;
        }

        [Test]
        public void QuoteDetailsTest()
        {
            Assert.IsNull(_microServiceContext.QuoteDetails);
            var data = new List<QuoteDetails>();
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
                ClientID = 1,
                ClientName = "Balaji",
                DateOfBirth = DateTime.Now,
                EmailID = "balaji.s1@cognizant.com",
                InvestmentAmount = 6000,
                MaturityAmount = 50000,
                MobileNumber = "9791563311",
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
            _microServiceContext.QuoteDetails = mockDbSet.Object;
            Assert.IsNotNull(_microServiceContext.QuoteDetails);
        }
    }
}
