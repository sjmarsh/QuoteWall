using AutoMapper;
using Raven.Client;
using QuoteWall.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuoteWall.Data
{
    public interface IQuoteRepository
    {
        IEnumerable<Quote> All();
        Quote Retrieve(Guid id);
        Guid Create(Quote quote);
        void Update(Quote quote);
        void Delete(Guid id);
    }

    public class QuoteRepository : IQuoteRepository
    {
        private IDocumentSession _session;

        public QuoteRepository(IDocumentSession session)
        {
            _session = session;
        }
                
        public IEnumerable<Quote> All()
        {
            return _session.Query<Quote>();
        }

        public Quote Retrieve(Guid id)
        {
            return _session.Load<Quote>(id);
        }

        public Guid Create(Quote quote)
        {
            _session.Store(quote);
            _session.SaveChanges();
            return quote.Id;
        }

        public void Update(Quote quote)
        {
            var existingQuote = _session.Load<Quote>(quote.Id);
            if(existingQuote != null)
            {
                Mapper.CreateMap<Quote, Quote>();
                Mapper.Map(quote, existingQuote);

                _session.SaveChanges();
            }
            else
            {
                throw new ArgumentException(string.Format("Quote {0} not found.", quote.Id));
            }
        }

        public void Delete(Guid id)
        {
            var quote = Retrieve(id);
            if (quote != null)
            {
                _session.Delete<Quote>(quote);
            }

            // else ??
        }
    }
}
