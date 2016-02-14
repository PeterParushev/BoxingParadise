using BoxingParadiseBackend.DTOs;
using BoxingParadiseBackend.Services.Interfaces;
using System.Linq;
using System.Web.Mvc;

namespace BoxingParadise.Controllers
{
    public class MatchController : Controller
    {
        private readonly IMatchService m_MatchService;
        private readonly IBoxerService m_BoxerService;
        private readonly IVenueService m_VenueService;

        public MatchController(IMatchService matchService, IBoxerService boxerService, IVenueService venueService)
        {
            m_MatchService = matchService;
            m_BoxerService = boxerService;
            m_VenueService = venueService;
        }

        [HttpGet]
        public ActionResult Match(int? take, int? skip)
        {
            ViewBag.Matches = m_MatchService.GetMatches(take, skip);

            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Boxers = m_BoxerService.GetBoxers().Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Name });
            ViewBag.Venues = m_VenueService.GetVenues().Select(x => new SelectListItem() { Value = x.Id.ToString(), Text = x.Name });
            return View();
        }

        [HttpPost]
        public ActionResult Create(MatchDto match)
        {
            m_MatchService.SaveMatch(match);
            ViewBag.Matches = m_MatchService.GetMatches();
            return View("Match");
        }
    }
}