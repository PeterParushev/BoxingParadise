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
        public async Task<Match> MapFromDto(MatchDto matchDto)
        {
            return new Match
            {
                Id = matchDto.Id,
                VenueId = matchDto.VenueId,
                BoxerOneId = matchDto.BoxerOneId,
                BoxerTwoId = matchDto.BoxerTwoId,
                StartDate = matchDto.StartDate,
                Description = matchDto.Description,
                WinnerId = matchDto.WinnerId != 0 ? matchDto.WinnerId : null
            };
        }

        public MatchDto MapToDto(Match match)
        {
            return new MatchDto
            {
                Id = match.Id,
                VenueId = match.VenueId,
                BoxerOneId = match.BoxerOneId,
                BoxerTwoId = match.BoxerTwoId,
                StartDate = match.StartDate,
                Description = match.Description,
                WinnerId = match.WinnerId
            };
        }
    }
}