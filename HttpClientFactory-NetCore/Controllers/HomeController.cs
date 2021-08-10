using System;
using System.Net.Http;
using System.Threading.Tasks;
using HttpClientFactory_NetCore.CustomHttpClient;
using Microsoft.AspNetCore.Mvc;

namespace HttpClientFactory_NetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly MyWebSiteHttpClient _myWebSiteHttpClient;

        public HomeController(IHttpClientFactory httpClientFactory,MyWebSiteHttpClient myWebSiteHttpClient) //inject public
        {
            _httpClientFactory = httpClientFactory;
            _myWebSiteHttpClient = myWebSiteHttpClient;
        }
        [HttpGet("GetOneProses")]
        public async Task<ActionResult> GetOneProses()
        {
            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://www.harunayyildiz.com");
            string result = await client.GetStringAsync("/");
            return Ok(result);
        }
        [HttpGet("GetTwoProses")]
        public async Task<ActionResult> GetTwoProses()
        {
            var client = _httpClientFactory.CreateClient("myWebSite");
            string result = await client.GetStringAsync("/");
            return Ok(result);
        }

        [HttpGet("GetThreeProses")]
        public async Task<ActionResult> GetThreeProses()
        {
            string result = await _myWebSiteHttpClient.Client.GetStringAsync("/hakkimda/");
            return Ok(result);
        }
    }
}