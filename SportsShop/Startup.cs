using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CheckoutSystem
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IGreeter, Greeter>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app,
                              IHostingEnvironment env,
                              IConfiguration configuration,
                              IGreeter greeter,
                              ILogger<Startup> logger
                              )
        {

            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }

            // Displays files in the wwwroot folder and run the index..
            //app.UseDefaultFiles();
            app.UseStaticFiles();

            // this has the MVC Default Routs 
            //app.UseMvcWithDefaultRoute();

            // Creating a route overself..
            app.UseMvc(configureRouts);

            app.Run(async (context) =>
            {
                //var greeting = configuration["Greeting"];
                var greeting = greeter.getMessageOftheDay();
                await context.Response.WriteAsync($"{greeting} : {env.EnvironmentName }");
            });
        }

        private void configureRouts(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute("Default",
                "{Controller=Home}/{action=Index}/{Id?}");
        }
    }
}
