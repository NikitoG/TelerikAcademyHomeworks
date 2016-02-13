namespace TwitterLikeSystem.Controllers
{
    using System.Web.Mvc;
    using TwitterLikeSystem.Data;

    public class BaseController : Controller
    {
        public BaseController(IUowData data)
        {
            Data = data;
        }

        protected IUowData Data { get; set; }
    }
}