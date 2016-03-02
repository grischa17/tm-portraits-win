using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TuRM.Portrait.Startup))]
namespace TuRM.Portrait
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
