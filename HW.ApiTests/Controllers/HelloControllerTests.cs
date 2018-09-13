using Microsoft.VisualStudio.TestTools.UnitTesting;
using HW.Api.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW.Api.Common;
using System.Net.Http;
using System.Web.Http;

namespace HW.Api.Controllers.Tests
{
    [TestClass()]
    public class HelloControllerTests
    {
        [TestMethod()]
        public void GetHelloWorldTestConsole_ShouldReturnValue()
        {
            IGreeter greeter = new ConsoleGreeter();
            IWriter writer = new ConsoleWriter();

            HelloController helloController = new HelloController(greeter, writer)
            {
                Request = new HttpRequestMessage()
            };

            helloController.Request.SetConfiguration(new HttpConfiguration());
            HttpResponseMessage result = helloController.GetHelloWorld();

            Assert.IsNotNull(result);
            Assert.IsTrue(result.StatusCode == System.Net.HttpStatusCode.OK);
            
        }
    }
}