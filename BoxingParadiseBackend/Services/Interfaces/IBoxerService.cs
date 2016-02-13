using BoxingParadiseBackend.DTOs;
using System.Collections.Generic;

namespace BoxingParadiseBackend.Services.Interfaces
{
    public interface IBoxerService
    {
        IList<BoxerDto> GetBoxers();

        void CreateBoxer(BoxerDto boxer);

        void DeleteBoxer(int id);
    }
}