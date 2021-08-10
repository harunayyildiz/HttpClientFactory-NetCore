using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HttpClientFactory_NetCore.CustomHttpClient;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HttpClientFactory_NetCore
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //1. Yöntem Doðrudan Kullanarak
            services.AddHttpClient();

            //2. Yöntem domain'e özel named cliend oluþturmak. Birden fazla requestler için geçerlidir.Performanslýdýr.
            services.AddHttpClient("myWebSite", c =>
                {
                    c.BaseAddress = new Uri("https://www.harunayyildiz.com");
                    c.DefaultRequestHeaders.Add("CustomHeaderKey", "It-is-a-HttpClientFactory-Sample");
                }
            );

            //3. Yöntem domain'e özel custom typed client oluþturmak.
            services.AddHttpClient<MyWebSiteHttpClient>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
