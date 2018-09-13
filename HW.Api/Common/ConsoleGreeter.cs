using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HW.Api.Models;
using HW.Api.Repository;

namespace HW.Api.Common
{
    public class ConsoleGreeter : IGreeter
    {
        public ConsoleGreeter()
        {

        }
        public GreetingDto SayHello()
        {
            return new GreetingDto() { GreetingId = 0, GreetingText = "Hello world from console." };
        }
    }
}