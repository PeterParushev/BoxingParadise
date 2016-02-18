using BoxingParadiseBackend.DTOs;
using BoxingParadiseBackend.Services.Interfaces;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace BoxingParadise.Controllers
{
    public class MatchController : ApiController
    {
        private readonly IMatchService m_MatchService;

        public MatchController(IMatchService matchService)
        {
            m_MatchService = matchService;
        }

        [HttpGet]
        public async Task<MatchDto> Get(int id)
        {
            return await m_MatchService.GetMatchById(id).ConfigureAwait(false);
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Post(MatchDto match, string adminKey)
        {
            await m_MatchService.SaveMatch(match, adminKey).ConfigureAwait(false);
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(int id, string adminKey)
        {
            await m_MatchService.DeleteMatchById(id, adminKey).ConfigureAwait(false);
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> Cancel([FromUri] int matchId, string adminKey)
        {
            await m_MatchService.Cancel(matchId, adminKey).ConfigureAwait(false);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        public async Task<IList<MatchDto>> Get(string query, int? count = 10, int? skip = 0)
        {
            return await m_MatchService.GetMatches(count.Value, skip.Value, query);
        }

        [HttpPut]
        public async Task<HttpResponseMessage> Update(MatchDto match, string adminKey)
        {
            await m_MatchService.SaveMatch(match, adminKey).ConfigureAwait(false);
            return Request.CreateResponse(HttpStatusCode.Created);
        }
    }
}