using AutoMapper;
using BoxingParadiseBackend.DTOs;
using BoxingParadiseBackend.Models;
using BoxingParadiseBackend.Repositories.Interfaces;
using BoxingParadiseBackend.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BoxingParadiseBackend.Services
{
    public class VenueService : IVenueService
    {
        private readonly IVenueRepository m_VenueRepository;

        public VenueService(IVenueRepository venueRepository)
        {
            m_VenueRepository = venueRepository;
            Mapper.CreateMap<Venue, VenueDto>();
            Mapper.CreateMap<VenueDto, Venue>();
        }

        public IList<VenueDto> GetVenues()
        {
            return m_VenueRepository.GetVenues().Select(x => Mapper.Map<VenueDto>(x)).ToList();
        }

        public void DeleteVenue(int venueId)
        {
            m_VenueRepository.Delete(venueId);
        }

        public void CreateVenue(VenueDto venueDto)
        {
            m_VenueRepository.Persist(Mapper.Map<Venue>(venueDto));
        }
    }
}