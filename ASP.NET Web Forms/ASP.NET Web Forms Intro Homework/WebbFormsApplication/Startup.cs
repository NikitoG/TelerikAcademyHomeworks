using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebbFormsApplication.Startup))]
namespace WebbFormsApplication
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
