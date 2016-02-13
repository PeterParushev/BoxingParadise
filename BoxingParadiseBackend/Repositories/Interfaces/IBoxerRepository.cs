using BoxingParadiseBackend.Models;
using System.Collections.Generic;

namespace BoxingParadiseBackend.Repositories.Interfaces
{
    public interface IBoxerRepository
    {
        IList<Boxer> GetBoxers();

        void Persist(Boxer boxer);

        void Delete(int id);
    }
}