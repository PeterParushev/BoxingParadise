using AutoMapper;
using BoxingParadiseBackend.DTOs;
using BoxingParadiseBackend.Models;
using BoxingParadiseBackend.Repositories.Interfaces;
using BoxingParadiseBackend.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoxingParadiseBackend.Services
{
    public class MatchService : IMatchService
    {
        private readonly IMatchRepository m_MatchRepository;

        public MatchService(IMatchRepository matchRepository)
        {
            m_MatchRepository = matchRepository;
        }

        public async Task<MatchDto> GetMatchById(int id)
        {
            return Mapper.Map<MatchDto>(await m_MatchRepository.GetById(id));
        }

        public async Task SaveMatch(MatchDto match)
        {
            await m_MatchRepository.Persist(Mapper.Map<Match>(match)).ConfigureAwait(false);
        }

        public async Task DeleteMatchById(int id)
        {
            await m_MatchRepository.DeleteById(id).ConfigureAwait(false);
        }

        public async Task<IList<MatchDto>> GetMatches(int? count, int? skip)
        {
            return
                (await m_MatchRepository.GetMatches(count, skip).ConfigureAwait(false)).Select(
                    x => Mapper.Map<MatchDto>(x)).ToList();
        }

        public async Task Cancel(int matchId)
        {
            await m_MatchRepository.Cancel(matchId).ConfigureAwait(false);
        }
    }
}