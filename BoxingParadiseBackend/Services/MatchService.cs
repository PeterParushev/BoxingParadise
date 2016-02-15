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
        private readonly IUserService m_UserService;

        public MatchService(IMatchRepository matchRepository, IUserService userService)
        {
            m_MatchRepository = matchRepository;
            m_UserService = userService;
        }

        public async Task<MatchDto> GetMatchById(int id)
        {
            return Mapper.Map<MatchDto>(await m_MatchRepository.GetById(id));
        }

        public async Task SaveMatch(MatchDto matchDto)
        {
            Match match = Mapper.Map<Match>(matchDto);
            await m_MatchRepository.Persist(match).ConfigureAwait(false);
            m_UserService.UpdateUserRatings(match);
        }

        public async Task DeleteMatchById(int id)
        {
            await m_MatchRepository.DeleteById(id).ConfigureAwait(false);
        }

        public async Task<IList<MatchDto>> GetMatches(int? take, int? skip)
        {
            return
                (await m_MatchRepository.GetMatches(take, skip).ConfigureAwait(false)).Select(
                    x => Mapper.Map<MatchDto>(x)).ToList();
        }

        public async Task Cancel(int matchId)
        {
            await m_MatchRepository.Cancel(matchId).ConfigureAwait(false);
        }

        public async Task<IList<MatchDto>> GetMatches(int? take, int? skip, string query)
        {
            return (await m_MatchRepository.GetMatches(take, skip, query)).Select(x => Mapper.Map<MatchDto>(x)).ToList();
        }
    }
}