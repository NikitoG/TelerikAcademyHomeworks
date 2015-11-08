namespace StudentSystem.Api
{
    using System.Web;
    using System.Web.Http;
    using StudentSystem.Api.App_Start;

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            DatabaseConfig.Initialize();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
