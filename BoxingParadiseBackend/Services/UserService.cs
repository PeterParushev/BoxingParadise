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
    public class UserService : IUserService
    {
        private readonly IUserRepository m_UserRepository;
        private readonly IBetRepository m_BetRepository;
        private readonly IMatchRepository m_MatchRepository;

        public UserService(IUserRepository userRepository, IBetRepository betRepository, IMatchRepository matchRepository)
        {
            m_UserRepository = userRepository;
            m_BetRepository = betRepository;
            m_MatchRepository = matchRepository;
        }

        public async Task<UserDto> GetUser(int id)
        {
            return Mapper.Map<UserDto>(await m_UserRepository.GetById(id).ConfigureAwait(false));
        }

        public async Task CreateUser(UserDto user)
        {
            await m_UserRepository.PersistUser(Mapper.Map<User>(user)).ConfigureAwait(false);
        }

        public async Task DeleteUser(int userId)
        {
            await m_UserRepository.DeleteUser(userId).ConfigureAwait(false);
        }

        public async Task<IList<UserDto>> GetUser(int take, int skip)
        {
            return
                (await m_UserRepository.GetUsers(take, skip).ConfigureAwait(false)).Select(x => Mapper.Map<UserDto>(x)).ToList();
        }

        internal void UpdateUserRatings(Match match)
        {
            IList<Bet> betsForThisMatch = m_BetRepository.GetAllBetsByMatchId(match.Id);

            foreach (var betForThisMatch in betsForThisMatch)
            {
                User user = m_UserRepository.GetById(betForThisMatch.User.Id).Result;

                IList<Bet> betsByUser = m_BetRepository.GetBetsByUserId(user.Id).Result;

                user.Rating = (double)betsByUser.Count(x => x.Boxer.Id == m_MatchRepository.GetById(x.Match.Id).Result.Winner.Id) / betsByUser.Count();
            }
        }
    }
}