using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Mvc.Razor;
using Microsoft.Data.Entity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.OptionsModel;
using TuRM.User.Models;
using TuRM.User.Services;

namespace TuRM.User
{
    // This project can output the Class library as a NuGet Package.
    // To enable this option, right-click on the project and select the Properties menu item. In the Build tab select "Produce outputs on build".
    public class UserStartup
    {
        public UserStartup()
        {

        }

        public void ConfigureServices(IServiceCollection services, IConfigurationRoot Configuration)
        {
            // Add framework services.
            services.AddEntityFramework()
                .AddSqlServer()
                .AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(Configuration["Data:DefaultConnection:ConnectionString"]));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();
        }

        public void AddServices(IServiceCollection services)
        {
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
        }

        public void Configure(IApplicationBuilder app)
        {

            // For more details on creating database during deployment see http://go.microsoft.com/fwlink/?LinkID=615859
            try
            {
                using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
                    .CreateScope())
                {
                    serviceScope.ServiceProvider.GetService<ApplicationDbContext>()
                         .Database.Migrate();
                }
            }
            catch { }

            

            IOptions<RazorViewEngineOptions> options = app.ApplicationServices.GetService<IOptions<RazorViewEngineOptions>>();

            options.Value.FileProvider
        }
    }
}
