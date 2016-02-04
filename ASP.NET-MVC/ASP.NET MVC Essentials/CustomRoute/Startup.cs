using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CustomRoute.Startup))]
namespace CustomRoute
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
