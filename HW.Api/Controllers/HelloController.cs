using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Description;
using HW.Api.Common;
using HW.Api.Models;

namespace HW.Api.Controllers
{
    [RoutePrefix("api")]
    public class HelloController : ApiController
    {
        IGreeter greeter;
        IWriter writer;

        public HelloController(IGreeter greeter, IWriter writer)
        {
            this.greeter = greeter;
            this.writer = writer;
        }


        [Route("hello")]
        [HttpGet]
        [ResponseType(typeof(string))]
        public HttpResponseMessage GetHelloWorld()
        {
            GreetingDto greetingDto = greeter.SayHello();

            return (greetingDto == null) ? Request.CreateResponse(HttpStatusCode.BadRequest, "error") :  Request.CreateResponse(HttpStatusCode.OK, greetingDto.GreetingText);
        }
    }
}