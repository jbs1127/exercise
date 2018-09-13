using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HW.Api.Repository
{
    public class GreetingRepository : IRepository
    {
        public Greeting GetGreeting()
        {
            Greeting greeting = null;
            using (var db = new HelloDbContext())
            {
                greeting = db.Greetings.FirstOrDefault();
            }

            return greeting;
        }
    }
}