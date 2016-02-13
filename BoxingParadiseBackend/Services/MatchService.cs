﻿using AutoMapper;
using BoxingParadiseBackend.DTOs;
using BoxingParadiseBackend.Models;
using BoxingParadiseBackend.Repositories.Interfaces;
using BoxingParadiseBackend.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BoxingParadiseBackend.Services
{
    public class MatchService : IMatchService
    {
        private readonly IMatchRepository m_MatchRepository;

        public MatchService(IMatchRepository matchRepository)
        {
            m_MatchRepository = matchRepository;
            Mapper.CreateMap<Match, MatchDto>();
            Mapper.CreateMap<MatchDto, Match>();
        }

        public MatchDto GetMatchById(int id)
        {
            return Mapper.Map<MatchDto>(m_MatchRepository.GetById(id));
        }

        public void SaveMatch(MatchDto match)
        {
            m_MatchRepository.Persist(Mapper.Map<Match>(match));
        }

        public void DeleteMatchById(int id)
        {
            m_MatchRepository.DeleteById(id);
        }

        public IList<MatchDto> GetMatches(int count, int skip)
        {
            return m_MatchRepository.GetMatches(count, skip).Select(x => Mapper.Map<MatchDto>(x)).ToList();
        }
    }
}