using System;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace APITestClient
{
    class TestClientAPI
    {
        class LincUser
        {
            public string email { get; set; }
            public string contact_number { get; set; }
            public string linc_id { get; set; }
            public string name { get; set; }
            public string company { get; set; }
            public string password { get; set; }
        }

        static async Task Main(string[] args)
        {
            var u = new LincUser();

            u.email = "myatkk@ccn.com.sg";
            u.name = "Ko Ko";
            u.company = "CCN";
            u.contact_number = "90255487";            
            u.linc_id = Convert.ToString(System.Guid.NewGuid());
            u.password = "helloworld";

            var json = JsonConvert.SerializeObject(u);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = @"http://89.108.108.225:8000/api/users/linc/"; 

            using (var client = new HttpClient())
            {
                var response = await client.PostAsync(url, data);
                string result = response.Content.ReadAsStringAsync().Result;
                Console.WriteLine(result);
            }
            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }        
    }
}
