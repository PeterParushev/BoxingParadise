using BoxingParadiseBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoxingParadiseBackend.Repositories.Interfaces
{
    public interface IBetRepository
    {
        Task<IList<Bet>> GetBetsByUserId(int userId);

        Task Persist(Bet bet);

        Task CancelBet(int betId);
    }
}