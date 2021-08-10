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
            //1. Y�ntem Do�rudan Kullanarak
            services.AddHttpClient();

            //2. Y�ntem domain'e �zel named cliend olu�turmak. Birden fazla requestler i�in ge�erlidir.Performansl�d�r.
            services.AddHttpClient("myWebSite", c =>
                {
                    c.BaseAddress = new Uri("https://www.harunayyildiz.com");
                    c.DefaultRequestHeaders.Add("CustomHeaderKey", "It-is-a-HttpClientFactory-Sample");
                }
            );

            //3. Y�ntem domain'e �zel custom typed client olu�turmak.
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
