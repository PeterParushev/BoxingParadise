using System;

namespace BoxingParadiseBackend.DTOs
{
    public class MatchDto
    {
        public int Id { get; set; }
        public BoxerDto BoxerOneDto { get; set; }
        public BoxerDto BoxerTwoDto { get; set; }
        public VenueDto VenueDto { get; set; }
        public DateTime StartDate { get; set; }
        public string Description { get; set; }
        public BoxerDto WinnerDto { get; set; }
    }
}