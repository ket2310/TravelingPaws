using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
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

        public IEmailService _emailService { get; }

        public InMemoryQuotesController(IInMemoryQuoteRepository inMemoryQuoteRepository, IEmailService emailService)
        {
            _quoteRepository = inMemoryQuoteRepository;
            _emailService = emailService;
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

        // POST: api/InMemoryQuotes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Quote>> PostQuote(QuoteMap quote)
        {
            return Ok(await _quoteRepository.CreateAQuote(quote));
        }


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

