using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InformationalSite.Startup))]
namespace InformationalSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
