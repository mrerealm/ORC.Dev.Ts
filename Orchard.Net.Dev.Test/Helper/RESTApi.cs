using Orchard.Net.Dev.Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace Orchard.Net.Dev.Test.Helper
{
    public class RESTApi
    {
        public static string ApiUrl { get; set; } = "https://jsonplaceholder.typicode.com/";

        public static System.Net.HttpStatusCode HttpPost(Post p)
        {
            using (var client = new HttpClient())
            {
                var response = client.PostAsJsonAsync($"{ApiUrl}posts", p).Result;
                return (response.IsSuccessStatusCode) ? System.Net.HttpStatusCode.Created : System.Net.HttpStatusCode.BadRequest;
            }
        }
    }
}