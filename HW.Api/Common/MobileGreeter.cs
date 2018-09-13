using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HW.Api.Models;

namespace HW.Api.Common
{
    public class MobileGreeter : IGreeter
    {
        public MobileGreeter()
        {

        }
        public GreetingDto SayHello()
        {
            return new GreetingDto() { GreetingId = 0, GreetingText = "Hello world from mobile" };
        }
    }
}