using BoxingParadiseBackend.DTOs;
using System.Collections.Generic;

namespace BoxingParadiseBackend.Services.Interfaces
{
    public interface IVenueService
    {
        IList<VenueDto> GetVenues();

        void DeleteVenue(int venueId);

        void CreateVenue(VenueDto venueDto);
    }
}