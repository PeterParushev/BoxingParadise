using BoxingParadiseBackend.DTOs;
using BoxingParadiseBackend.Services.Interfaces;
using System.Web.Mvc;

namespace BoxingParadise.Controllers
{
    public class BoxerController : Controller
    {
        private readonly IBoxerService m_BoxerService;

        public BoxerController(IBoxerService boxerService)
        {
            m_BoxerService = boxerService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            ViewBag.Boxers = m_BoxerService.GetBoxers();
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(BoxerDto boxer)
        {
            m_BoxerService.CreateBoxer(boxer);
            ViewBag.Boxers = m_BoxerService.GetBoxers();
            return View("Get");
        }
    }
}