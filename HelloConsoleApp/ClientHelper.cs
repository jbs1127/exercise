using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace HelloConsoleApp
{
    class ClientHelper
    {
        private static HttpClient Client = new HttpClient();

        public ClientHelper()
        {
        }

        public (bool, string) GetRequest(string url)
        {
            bool isOk = false;
            string responseBody = string.Empty;

            HttpResponseMessage response = Client.GetAsync(WebConfigurationManager.AppSettings["greeting:apiBaseUrl"] + url).Result;

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                isOk = true;
                responseBody = response.Content.ReadAsStringAsync().Result;
            }

            return (isOk, responseBody);
        }
    }
}
