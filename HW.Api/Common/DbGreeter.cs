using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HW.Api.Models;
using HW.Api.Repository;

namespace HW.Api.Common
{
    public class DbGreeter : IGreeter
    {
        IRepository repository;
        public DbGreeter(IRepository repository)
        {
            this.repository = repository;
        }
        public GreetingDto SayHello()
        {
            Greeting entity = repository.GetGreeting();

            if (entity == null)
                return null;

            return new GreetingDto()
            {
                GreetingId = entity.GreetingId,
                GreetingText = entity.GreetingText
            };
        }
    }
}