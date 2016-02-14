using BoxingParadiseBackend.DTOs;
using BoxingParadiseBackend.Services.Interfaces;
using System.Web.Mvc;

namespace BoxingParadise.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService m_UserService;

        public UserController(IUserService userService)
        {
            m_UserService = userService;
        }

        [HttpPost]
        public ActionResult Create(UserDto user)
        {
            return new ContentResult();
        }
    }
}