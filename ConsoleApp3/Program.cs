using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();
        static async Task Main()
        {
            //var first = client.GetAsync("http://www.google.com");
            //var seond = client.GetAsync("http://www.quipu.de");

            var tasks = new List<Task<HttpResponseMessage>>();
            try
            {
                tasks.Add(client.GetAsync("http://www.google.com"));
                tasks.Add(client.GetAsync("http://www.quipu.de"));

                await Task.WhenAll(tasks);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            // var results = tasks.Select(t => t.Result);

            Console.WriteLine(tasks.All(t => t.IsCompleted));

            var results = tasks.Select(t => t.Result);

            foreach (var res in results)
            {
                Console.WriteLine(res);
            }

        }
    }
}
