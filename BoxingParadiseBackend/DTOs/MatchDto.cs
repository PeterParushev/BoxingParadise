using System;

namespace BoxingParadiseBackend.DTOs
{
    public class MatchDto
    {
        public int BoxerDtoOneId { get; set; }
        public int BoxerDtoTwoId { get; set; }
        public int VenueDtoId { get; set; }
        public DateTime StartDate { get; set; }
        public string Description { get; set; }
        public int WinnerId { get; set; }
    }
}