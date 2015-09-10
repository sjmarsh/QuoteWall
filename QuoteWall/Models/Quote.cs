using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuoteWall.Models
{
    public class Quote
    {
        public Guid Id { get; set; }
        public string QuoteText { get; set; }
        public string Quoter { get; set; }
        public DateTime DateAdded { get; set; }
        public int Rating { get; set; }
    }
}