using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CryptoController : ControllerBase
    {
        [HttpGet("GetCrypto")]
        public List<Crypto>  Get()
        {
            var listCryptos = new List<Crypto>();
            //string url = "https://api.coingecko.com/api/v3/coins/markets?vs_currency=brl";
            string url = "https://api.coingecko.com/api/v3/coins/markets?vs_currency=brl";
            var httpclient = new HttpClient();
            //var request = new HttpRequestMessage();

            var response = httpclient.GetAsync(url).Result;
            var data = response.Content.ReadAsStringAsync().Result;


            var set = new JsonSerializerSettings { 
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore 
            };

            listCryptos = JsonConvert.DeserializeObject<List<Crypto>>(data, set);
            Console.WriteLine(listCryptos[0].Name);
            return listCryptos;

        }
    }
}