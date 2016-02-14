using BoxingParadiseBackend.DTOs;
using BoxingParadiseBackend.Services.Interfaces;
using System.Web.Mvc;

namespace BoxingParadise.Controllers
{
    public class MatchController : Controller
    {
        private readonly IMatchService m_MatchService;

        public MatchController(IMatchService matchService)
        {
            m_MatchService = matchService;
        }

        //
        // GET: /Match/
        [HttpGet]
        public ActionResult Match(int? take, int? skip)
        {
            ViewBag.Matches = m_MatchService.GetMatches(take, skip);

            return View();
        }

        [HttpPut]
        public ActionResult Post(MatchDto match)
        {
            m_MatchService.SaveMatch(match);
            ViewBag.Matches = m_MatchService.GetMatches();
            return View();
        }
    }
}