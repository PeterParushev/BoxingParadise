using System.Web.Mvc;

namespace BoxingParadise.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult Get(int take, int skip)
        {
            return View()
        }
    }
}