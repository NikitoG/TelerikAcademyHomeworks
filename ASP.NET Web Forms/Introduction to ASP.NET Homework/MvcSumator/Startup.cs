using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcSumator.Startup))]
namespace MvcSumator
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
