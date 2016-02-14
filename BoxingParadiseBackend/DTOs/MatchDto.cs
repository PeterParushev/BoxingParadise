using System;

namespace BoxingParadiseBackend.DTOs
{
    public class MatchDto
    {
        public BoxerDto FirstBoxerDto { get; set; }
        public BoxerDto SecondBoxerDto { get; set; }
        public VenueDto VenueDto { get; set; }
        public DateTime StartDate { get; set; }
        public string Description { get; set; }
        public BoxerDto WinnerDto { get; set; }
    }
}