using BoxingParadiseBackend.DTOs;
using BoxingParadiseBackend.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace BoxingParadiseBackend.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserService m_UserSevice;

        public UserController(IUserService userSevice)
        {
            m_UserSevice = userSevice;
        }

        [HttpGet]
        public async Task<UserDto> Get(int id)
        {
            return await m_UserSevice.GetUser(id).ConfigureAwait(false);
        }

        [HttpPost]
        public async Task Post(UserDto user)
        {
            await m_UserSevice.CreateUser(user).ConfigureAwait(false);
        }

        [HttpDelete]
        public async Task Delete(int userId)
        {
            await m_UserSevice.DeleteUser(userId).ConfigureAwait(false);
        }

        [HttpGet]
        public async Task<IList<UserDto>> Get(int take, int skip)
        {
            return await m_UserSevice.GetUser(take, skip).ConfigureAwait(false);
        }
    }
}