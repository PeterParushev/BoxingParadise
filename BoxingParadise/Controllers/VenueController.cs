using BoxingParadiseBackend.DTOs;
using BoxingParadiseBackend.Services.Interfaces;
using System.Web.Mvc;

namespace BoxingParadise.Controllers
{
    public class VenueController : Controller
    {
        private readonly IVenueService m_VenueService;

        public VenueController(IVenueService venueService)
        {
            m_VenueService = venueService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.Venues = m_VenueService.GetVenues().Result;
            return View();
        }

        [HttpGet]
        public ActionResult Venue()
        {
            return Index();
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Venues = m_VenueService.GetVenues().Result;
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(VenueDto venue)
        {
            m_VenueService.CreateVenue(venue);
            ViewBag.Venues = m_VenueService.GetVenues().Result;
            return View("Index");
        }
    }
}