using BoxingParadiseBackend.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoxingParadiseBackend.Services.Interfaces
{
    public interface IBoxerService
    {
        Task<IList<BoxerDto>> GetBoxers();

        Task CreateBoxer(BoxerDto boxer);

        Task DeleteBoxer(int id);
    }
}