using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TravelingPawsAPI.Maps;
using TravelingPawsAPI.Models;
using TravelingPawsAPI.Repositories;

namespace TravelingPawsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InMemoryQuotesController : ControllerBase
    {
        private readonly IInMemoryQuoteRepository _quoteRepository;

        public InMemoryQuotesController(IInMemoryQuoteRepository inMemoryQuoteRepository)
        {
            _quoteRepository = inMemoryQuoteRepository;
        }

        // GET: api/InMemoryQuotes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quote>>> GetQuotes()
        {
            return Ok(await _quoteRepository.GetQuotes());
        }

        // GET: api/InMemoryQuotes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Quote>> GetQuote(int id)
        {
            return Ok(await _quoteRepository.GetQuote(id));
        }

        // PUT: api/InMemoryQuotes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuote(int id, Quote quote)
        {
            if (id != quote.QuoteId)
            {
                return BadRequest();
            }

            try
            {
                await _quoteRepository.UpdateQuote(quote);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuoteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/InMemoryQuotes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Quote>> PostQuote(QuoteMap quote)
        {
            return Ok(await _quoteRepository.CreateAQuote(quote));
        }

        // DELETE: api/InMemoryQuotes/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteQuote(int id)
        //{
        //    var quote = await _context.Quotes.FindAsync(id);
        //    if (quote == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Quotes.Remove(quote);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool QuoteExists(int id)
        {
            return _quoteRepository.DoesItLive(id);
        }
    }
}

