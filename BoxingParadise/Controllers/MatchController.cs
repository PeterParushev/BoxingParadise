using BoxingParadiseBackend.Services.Interfaces;
using System.Web.Mvc;

namespace BoxingParadise.Controllers
{
    public class MatchController : Controller
    {
        private IMatchService m_MatchService;

        public MatchController(IMatchService matchService)
        {
            m_MatchService = matchService;
        }

        //
        // GET: /Matches/
        [HttpGet]
        public ActionResult GetMatches(int? take, int? skip)
        {
            ViewBag.Matches = m_MatchService.GetMatches(take, skip);

            return View();
        }

        public ActionResult Index()
        {
            return View();
        }
    }
}