using AutoMapper;
using BoxingParadiseBackend.DTOs;
using BoxingParadiseBackend.Models;
using BoxingParadiseBackend.Repositories.Interfaces;
using BoxingParadiseBackend.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoxingParadiseBackend.Services
{
    public class VenueService : IVenueService
    {
        private readonly IVenueRepository m_VenueRepository;

        public VenueService(IVenueRepository venueRepository)
        {
            m_VenueRepository = venueRepository;
        }

        public async Task<IList<VenueDto>> GetVenues()
        {
            return
                (await m_VenueRepository.GetVenues().ConfigureAwait(false)).Select(x => Mapper.Map<VenueDto>(x))
                    .ToList();
        }

        public async Task DeleteVenue(int venueId)
        {
            await m_VenueRepository.Delete(venueId).ConfigureAwait(false);
        }

        public async Task CreateVenue(VenueDto venueDto)
        {
            await m_VenueRepository.Persist(Mapper.Map<Venue>(venueDto)).ConfigureAwait(false);
        }
    }
}