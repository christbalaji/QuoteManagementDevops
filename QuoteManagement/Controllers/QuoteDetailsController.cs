using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuoteManagement.Interface;
using QuoteManagement.Models;

namespace QuoteManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteDetailsController : ControllerBase
    {
        private readonly IQuoteDetailsService _service;

        public QuoteDetailsController(IQuoteDetailsService service)
        {
            _service = service;
        }

        // GET: api/QuoteDetails
        [HttpGet]
        public async Task<IEnumerable<QuoteDetails>> GetQuoteDetails()
        {
            return await _service.GetQuoteDetails();
        }

        // GET: api/QuoteDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QuoteDetails>> GetQuoteDetails(int id)
        {
            var quoteDetails = await _service.GetQuoteDetails(id);

            if (quoteDetails == null)
            {
                return NotFound();
            }

            return quoteDetails;
        }

        // PUT: api/QuoteDetails/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<ActionResult<QuoteDetails>> PutQuoteDetails(int id, QuoteDetails quoteDetails)
        {
            if (id != quoteDetails.ClientID)
            {
                return BadRequest();
            }

            await _service.PutQuoteDetails(id, quoteDetails);
            return Ok(new { id = quoteDetails.ClientID });
        }

        // POST: api/QuoteDetails
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<QuoteDetails>> PostQuoteDetails(QuoteDetails quoteDetails)
        {
            await _service.PostQuoteDetails(quoteDetails);
            return CreatedAtAction("PostQuoteDetails", new { id = quoteDetails.ClientID }, quoteDetails);
        }

        // DELETE: api/QuoteDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<QuoteDetails>> DeleteQuoteDetails(int id)
        {
            var quoteDetails = await _service.GetQuoteDetails(id);
            if (quoteDetails == null)
            {
                return NotFound();
            }

            await _service.DeleteQuoteDetails(id);

            return quoteDetails;
        }
    }
}
