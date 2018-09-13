using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW.Api.Repository
{
    public class HelloDbContext : IDisposable
    {
        public List<Greeting> Greetings { get; set; }
        public HelloDbContext()
        {
            Greetings = new List<Greeting>()
            {
                new Greeting(){GreetingId = 1, GreetingText = "Hello world from DB"}
            };
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}