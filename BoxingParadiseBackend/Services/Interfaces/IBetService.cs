using BoxingParadiseBackend.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoxingParadiseBackend.Services.Interfaces
{
    public interface IBetService
    {
        Task<IList<BetDto>> GetBetsByUserId(int userId);

        Task CreateBet(BetDto bet);

        Task DeleteBet(int betId);
    }
}