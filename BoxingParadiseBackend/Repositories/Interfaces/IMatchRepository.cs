﻿using BoxingParadiseBackend.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoxingParadiseBackend.Repositories.Interfaces
{
    public interface IMatchRepository
    {
        Task<Match> GetById(int id);

        Task Persist(Match match);

        Task DeleteById(int id);

        Task<IList<Match>> GetMatches(int? take, int? skip);

        Task Cancel(int matchId);

        Task<IList<Match>> GetMatches(int? take, int? skip, string searchWord);
    }
}