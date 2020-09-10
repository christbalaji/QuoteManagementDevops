using QuoteManagement.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuoteManagement.Interface
{
    public interface IQuoteDetailsService
    {
        Task<IEnumerable<QuoteDetails>> GetQuoteDetails();
        Task<QuoteDetails> GetQuoteDetails(int id);
        Task<QuoteDetails> PutQuoteDetails(int id, QuoteDetails quoteDetails);
        Task<QuoteDetails> PostQuoteDetails(QuoteDetails quoteDetails);
        Task<QuoteDetails> DeleteQuoteDetails(int id);
    }
}
