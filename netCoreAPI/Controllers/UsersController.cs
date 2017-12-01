using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using netCoreAPI.Models;
using System.Text;

namespace netCoreAPI.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        // GET api/values
        [HttpGet]
        public Task<string> Get()
        {
            return this.GetData();
        }

        private async Task<string> GetData()
        {
            //We will make a GET request to a really cool website...

            string baseUrl = "http://localhost:30031/api/v1/getall";
            //The 'using' will help to prevent memory leaks.
            //Create a new instance of HttpClient
            using (HttpClient client = new HttpClient())

            //Setting up the response...         

            using (HttpResponseMessage res = await client.GetAsync(baseUrl))
            using (HttpContent content = res.Content)
            {
                string data = await content.ReadAsStringAsync();
                if (data != null)
                {
                    return data;
                }

                return string.Empty;
            }
        }
    }
}
