using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpClientFactory_NetCore.CustomHttpClient
{
    public class MyWebSiteHttpClient
    {
        public HttpClient Client { get; private set; }

        public MyWebSiteHttpClient(HttpClient httpClient)
        {
            httpClient.BaseAddress = new Uri("https://www.harunayyildiz.com/");
            httpClient.DefaultRequestHeaders.Add("CustomHeaderKey", "It-is-a-HttpClientFactory-Sample");
            Client = httpClient;
        }
    }
}
