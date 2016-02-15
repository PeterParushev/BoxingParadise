using BoxingParadiseBackend.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BoxingParadiseBackend.Services.Interfaces
{
    public interface IVenueService
    {
        Task<IList<VenueDto>> GetVenues();

        Task DeleteVenue(int venueId);

        Task CreateVenue(VenueDto venueDto);
    }
}