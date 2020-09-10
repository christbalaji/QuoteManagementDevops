using Microsoft.EntityFrameworkCore;
using QuoteManagement.Data;
using QuoteManagement.Interface;
using QuoteManagement.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuoteManagement.Service
{
    public class QuoteDetailsService : IQuoteDetailsService
    {
        private readonly QuoteManagementContext _context;

        public QuoteDetailsService(QuoteManagementContext context)
        {
            _context = context;
        }

        public async Task<QuoteDetails> DeleteQuoteDetails(int id)
        {
            var quoteDetails = await _context.QuoteDetails.FindAsync(id);

            _context.QuoteDetails.Remove(quoteDetails);
            await _context.SaveChangesAsync();

            return quoteDetails;
        }

        public async Task<IEnumerable<QuoteDetails>> GetQuoteDetails()
        {
            return await _context.QuoteDetails.ToListAsync();
        }

        public async Task<QuoteDetails> GetQuoteDetails(int id)
        {
            var quoteDetails = await _context.QuoteDetails.FindAsync(id);

            return quoteDetails;
        }

        public async Task<QuoteDetails> PostQuoteDetails(QuoteDetails quoteDetails)
        {
            quoteDetails.MaturityAmount = calculateMaturityAmount(quoteDetails);
            _context.QuoteDetails.Add(quoteDetails);
            await _context.SaveChangesAsync();
            return quoteDetails;
        }

        public async Task<QuoteDetails> PutQuoteDetails(int id, QuoteDetails quoteDetails)
        {
            quoteDetails.MaturityAmount = calculateMaturityAmount(quoteDetails);
            _context.Entry(quoteDetails).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return quoteDetails;
        }

        private decimal calculateMaturityAmount(QuoteDetails quoteDetails)
        {
            decimal factor = 0;
            if (quoteDetails.PensionPlan == PensionPlans.PensionSilver)
            {
                factor = Convert.ToDecimal(0.02);
            }
            else if (quoteDetails.PensionPlan == PensionPlans.PensionGold)
            {
                factor = Convert.ToDecimal(0.04);
            }
            else if (quoteDetails.PensionPlan == PensionPlans.PensionPlatinum)
            {
                factor = Convert.ToDecimal(0.06);
            }

            int currentAge = DateTime.Now.Year - quoteDetails.DateOfBirth.Year;
            if (DateTime.Now.DayOfYear < quoteDetails.DateOfBirth.DayOfYear)
                currentAge = currentAge - 1;

            return quoteDetails.InvestmentAmount * (1 + factor) * (quoteDetails.RetirementAge - currentAge) / 100;
        }
    }
}
