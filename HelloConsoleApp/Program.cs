using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ClientHelper helper = new ClientHelper();
            (bool isOk, string response) = helper.GetRequest("/api/hello");

            Console.WriteLine(response);
            Console.ReadKey();
        }
    }
}
