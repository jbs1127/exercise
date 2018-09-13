using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HW.Api.Repository;

namespace HW.Api.Common
{
    public class DbWriter : IWriter
    {
        IRepository repository;
        public DbWriter(IRepository repository)
        {
            this.repository = repository;
        }

        public void WriteGreeting(string greetingText)
        {
            // write text to repository
        }
    }
}