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

        //[HttpGet]
        //public async Task<MatchDto> Get(int id)
        //{
        //    return await m_MatchService.GetMatchById(id).ConfigureAwait(false);
        //}

        [HttpPost]
        public async Task<HttpResponseMessage> Post(MatchDto match)
        {
            await m_MatchService.SaveMatch(match).ConfigureAwait(false);
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(int id)
        {
            await m_MatchService.DeleteMatchById(id).ConfigureAwait(false);
            return Request.CreateResponse(HttpStatusCode.NoContent);
        }

        [HttpGet]
        public async Task<IList<MatchDto>> Get(int? count = 10, int? skip = 0)
        {
            return await m_MatchService.GetMatches(count, skip).ConfigureAwait(false);
        }

        [HttpPut]
        public async Task<HttpResponseMessage> Put(int matchId)
        {
            await m_MatchService.Cancel(matchId).ConfigureAwait(false);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        //[HttpGet]
        //public async Task<IList<MatchDto>> Get(string query, int? count = 10, int? skip = 0)
        //{
        //    return await m_MatchService.GetMatches(count.Value, skip.Value, query);
        //}
    }
}