using System;

namespace BoxingParadiseBackend.DTOs
{
    public class MatchDto
    {
        public int Id { get; set; }
        public int BoxerOneId { get; set; }
        public int BoxerTwoId { get; set; }
        public int VenueId { get; set; }
        public DateTime StartDate { get; set; }
        public string Description { get; set; }
        public int? WinnerId { get; set; }
    }
}