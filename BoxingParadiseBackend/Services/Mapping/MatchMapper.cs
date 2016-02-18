using AutoMapper;
using BoxingParadiseBackend.DTOs;
using BoxingParadiseBackend.Models;
using BoxingParadiseBackend.Repositories.Interfaces;
using BoxingParadiseBackend.Services.Mapping.Interface;
using System.Threading.Tasks;

namespace BoxingParadiseBackend.Services.Mapping
{
    public class MatchMapper : IMatchMapper
    {
        private readonly IBoxerRepository m_BoxerRepository;
        private readonly IVenueRepository m_VenueRepository;

        public MatchMapper(IBoxerRepository boxerRepository, IVenueRepository venueRepository)
        {
            m_BoxerRepository = boxerRepository;
            m_VenueRepository = venueRepository;
        }

        public async Task<Match> MapFromDto(MatchDto matchDto)
        {
            return new Match
            {
                Id = matchDto.Id,
                Venue = await m_VenueRepository.GetById(matchDto.VenueDto.Id).ConfigureAwait(false),
                BoxerOne = await m_BoxerRepository.GetById(matchDto.BoxerOneDto.Id).ConfigureAwait(false),
                BoxerTwo = await m_BoxerRepository.GetById(matchDto.BoxerTwoDto.Id).ConfigureAwait(false),
                StartDate = matchDto.StartDate,
                Description = matchDto.Description,
                Winner = await m_BoxerRepository.GetById(matchDto.WinnerDto.Id).ConfigureAwait(false)
            };
        }

        public MatchDto MapToDto(Match match)
        {
            return new MatchDto
            {
                Id = match.Id,
                VenueDto = Mapper.Map<VenueDto>(match.Venue),
                BoxerOneDto = Mapper.Map<BoxerDto>(match.BoxerOne),
                BoxerTwoDto = Mapper.Map<BoxerDto>(match.BoxerTwo),
                StartDate = match.StartDate,
                Description = match.Description,
                WinnerDto = Mapper.Map<BoxerDto>(match.Winner)
            };
        }
    }
}