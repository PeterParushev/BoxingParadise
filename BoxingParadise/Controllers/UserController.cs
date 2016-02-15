using System.Web.Mvc;

namespace BoxingParadise.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public ActionResult GetUsers(int take, int skip)
        {
            return View();
        }
    }
}