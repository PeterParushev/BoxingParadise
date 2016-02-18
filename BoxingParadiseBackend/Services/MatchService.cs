using BoxingParadiseBackend.DTOs;
using BoxingParadiseBackend.Models;
using BoxingParadiseBackend.Repositories.Interfaces;
using BoxingParadiseBackend.Services.Interfaces;
using BoxingParadiseBackend.Services.Mapping.Interface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoxingParadiseBackend.Services
{
    public class MatchService : IMatchService
    {
        private readonly IMatchRepository m_MatchRepository;
        private readonly IMatchMapper m_MatchMapper;
        private readonly IUserService m_UserService;
        private readonly IAdministratorService m_AdministratorService;

        public MatchService(IMatchRepository matchRepository, IMatchMapper matchMapper, IUserService userService,
            IAdministratorService administratorService)
        {
            m_MatchRepository = matchRepository;
            m_UserService = userService;
            m_MatchMapper = matchMapper;
            m_AdministratorService = administratorService;
        }

        public async Task<MatchDto> GetMatchById(int id)
        {
            return m_MatchMapper.MapToDto(await m_MatchRepository.GetById(id).ConfigureAwait(false));
        }

        public async Task SaveMatch(MatchDto matchDto, string adminKey)
        {
            Match match = m_MatchMapper.MapFromDto(matchDto).Result;
            await m_MatchRepository.Persist(match).ConfigureAwait(false);

            m_UserService.UpdateUserRatings(match);
        }

        public async Task DeleteMatchById(int id, string adminKey)
        {
            if (await m_AdministratorService.IsProvidedAdministratorKeyValid(adminKey))
            {
                await m_MatchRepository.DeleteById(id).ConfigureAwait(false);
            }
        }

        public async Task Cancel(int matchId, string adminKey)
        {
            if (await m_AdministratorService.IsProvidedAdministratorKeyValid(adminKey))
            {
                await m_MatchRepository.Cancel(matchId).ConfigureAwait(false);
            }
        }

        public async Task<IList<MatchDto>> GetMatches(int? take, int? skip, string query)
        {
            return
                (await m_MatchRepository.GetMatches(take, skip, query)).Select(x => m_MatchMapper.MapToDto(x)).ToList();
        }
    }
}