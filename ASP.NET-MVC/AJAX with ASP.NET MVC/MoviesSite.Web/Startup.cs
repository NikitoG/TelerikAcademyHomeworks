using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MoviesSite.Web.Startup))]
namespace MoviesSite.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
