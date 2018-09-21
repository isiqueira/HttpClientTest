using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace HttpClientTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add( new MediaTypeWithQualityHeaderValue("application/json"));

                var dta = new { name = "USER 1", number = "123456789", checksum = "0" };

                using (var queryString = new StringContent(JsonConvert.SerializeObject(dta), Encoding.UTF8, "application/json"))
                {
                    var response = client.PostAsync("", queryString).Result;
                    response.EnsureSuccessStatusCode();
                    var conteudo = response.Content.ReadAsStringAsync().Result;
                }
            }
        }
    }
}
