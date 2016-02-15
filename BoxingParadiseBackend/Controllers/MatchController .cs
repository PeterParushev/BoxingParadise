using AutoMapper;
using BoxingParadiseBackend.DTOs;
using BoxingParadiseBackend.Models;
using BoxingParadiseBackend.Repositories.Interfaces;
using BoxingParadiseBackend.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;

namespace BoxingParadiseBackend.Controllers
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
        public async Task Post(MatchDto match)
        {
            await m_MatchService.SaveMatch(match).ConfigureAwait(false);
        }

        [HttpDelete]
        public async Task DeleteMatchById(int id)
        {
            await m_MatchService.DeleteMatchById(id).ConfigureAwait(false);
        }

        [HttpGet]
        public async Task<IList<MatchDto>> GetMatches(int? count = 10, int? skip = 0)
        {
            return await m_MatchService.GetMatches(count, skip).ConfigureAwait(false);
        }

        [HttpPut]
        public async Task Put(int matchId)
        {
            await m_MatchService.Cancel(matchId).ConfigureAwait(false);
        }
    }
}