using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TravelingPawsAPI.DataContext;
using TravelingPawsAPI.Maps;
using TravelingPawsAPI.Models;
using TravelingPawsAPI.Repositories;

namespace TravelingPawsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private readonly IQuoteRepository _quoteRepository;

        public QuotesController(IQuoteRepository quoteRepository)
        {
            _quoteRepository = quoteRepository;
        }


        // GET: api/Quotes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quote>>> GetQuotes()
        {
            return Ok(await _quoteRepository.GetQuotes());
        }

        // GET: api/Quotes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Quote>> GetQuote(int id)
        {

            return Ok(await _quoteRepository.GetQuote(id));
        }

        // PUT: api/Quotes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut]
        public async Task<ActionResult<Quote>> UpdateQuote(Quote quote)
        {
            try
            {
                var theQuoteToUpdate = _quoteRepository.GetQuote(quote.QuoteId);
                if (theQuoteToUpdate == null)
                    return NotFound($"Quote with id of {quote.QuoteId} not found");


                return await _quoteRepository.UpdateQuote(quote);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuoteExists(quote.QuoteId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/Quotes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Quote>> PostQuote(QuoteMap quote)
        {
            return Ok(await _quoteRepository.CreateAQuote(quote));
        }      
        
        //// DELETE: api/Quotes/5
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

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Quote>> DeleteQuote(int id)
        {
            try
            {
                var quoteToDelete = await _quoteRepository.GetQuote(id);

                if (quoteToDelete == null)
                {
                    return NotFound($"Employee with Id = {id} not found");
                }

                return await _quoteRepository.DeleteQuote(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }
    }
}
