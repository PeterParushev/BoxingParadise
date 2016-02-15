using BoxingParadiseBackend.DTOs;
using BoxingParadiseBackend.Services.Interfaces;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BoxingParadiseBackend.Controllers
{
    public class BetController : ApiController
    {
        private readonly IBetService m_BetService;

        public BetController(IBetService betService)
        {
            m_BetService = betService;
        }

        [HttpGet]
        public async Task<IList<BetDto>> Get(int userId)
        {
            return
                (await m_BetService.GetBetsByUserId(userId).ConfigureAwait(false));
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Post(BetDto bet)
        {
            await m_BetService.CreateBet(bet).ConfigureAwait(false);
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(int betId)
        {
            await m_BetService.DeleteBet(betId).ConfigureAwait(false);
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }
    }
}