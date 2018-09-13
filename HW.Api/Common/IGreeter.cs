using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HW.Api.Models;

namespace HW.Api.Common
{
    public interface IGreeter
    {
        GreetingDto SayHello();

    }
}
