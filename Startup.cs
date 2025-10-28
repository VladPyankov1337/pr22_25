using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Shop.Data.Interfaces;
using Shop.Data.Mocks;

namespace Shop
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ICategorys, MockCategorys>();
            services.AddTransient<IItems, MockItems>();
            services.AddMvc(option => option.EnableEndpointRouting = false);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();

        }
    }
}
