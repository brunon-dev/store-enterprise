using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SE.WebApp.MVC.Configuration;

namespace SE.WebApp.MVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentityConfiguration();

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // a chamada do UseIdentityConfiguration (com o UseAuthentication e o UseAuthorization)
            // fica entre o UseRouting e o UseEndpoints, dentro do UseMvcConfiguration
            app.UseMvcConfiguration(env);
            
        }
    }
}
