using QuoteWall.Data;
using QuoteWall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QuoteWall.Controllers
{
    
    public class QuoteController : ApiController
    {
        private IQuoteRepository _quoteRepository;

        public QuoteController(IQuoteRepository quoteRepository)
        {
            _quoteRepository = quoteRepository;
        }
               
        [HttpGet]
        [Route("api/quotes/{id:Guid}")]
        public Quote Get(Guid id)
        {
            return _quoteRepository.Retrieve(id);
        }

        [HttpGet]
        [Route("api/quotes")]
        public IEnumerable<Quote> Get()
        {
            return _quoteRepository.All();
        }

        [HttpPost]
        [Route("api/quotes")]
        public Guid Post(Quote quote)
        {
            return _quoteRepository.Save(quote);
        }

        [HttpDelete]
        public void Delete(Guid id)
        {
            _quoteRepository.Delete(id);
        }

    }
}
