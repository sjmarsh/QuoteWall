using System;
using NUnit;
using NUnit.Framework;
using QuoteWall.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace QuoteWall.Test
{
    [TestFixture]
    public class QuoteWallApiTests
    {
        [Test]
        public void PoputlateSampleQuotes()
        {
            var quote1 = new Quote { QuoteText = "My cat's breath smells like cat food.", Quoter = "Ralph", DateAdded = DateTime.Today.AddDays(-2), Rating = 0 };
            var quote2 = new Quote { QuoteText = "Trying is the first step towards failure.", Quoter = "Homer", DateAdded = DateTime.Today.AddDays(-1), Rating = 1 };

            CreateQuote(quote1).Wait();
            CreateQuote(quote2).Wait();
        }

        private async Task CreateQuote(Quote quote)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:4080/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.PostAsJsonAsync("api/quotes", quote);

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content;
                }
                else 
                {
                    var status = response.StatusCode;
                }
            }
        }
    }
}
