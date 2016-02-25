using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LetPaintPictures.Startup))]
namespace LetPaintPictures
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
