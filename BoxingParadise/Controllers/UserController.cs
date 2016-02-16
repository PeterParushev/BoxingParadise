using BoxingParadiseBackend.DTOs;
using BoxingParadiseBackend.Services.Interfaces;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BoxingParadise.Controllers
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
        public async Task<HttpResponseMessage> Post(UserDto user)
        {
            await m_UserSevice.CreateUser(user).ConfigureAwait(false);
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(int userId)
        {
            await m_UserSevice.DeleteUser(userId).ConfigureAwait(false);
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        [HttpGet]
        public async Task<IList<UserDto>> Get(int take, int skip)
        {
            return await m_UserSevice.GetUser(take, skip).ConfigureAwait(false);
        }
    }
}