using System;

namespace BoxingParadiseBackend.DTOs
{
    public class MatchDto
    {
        public int BoxerDtoOneId;
        public int BoxerDtoTwoId;
        public int VenueDtoId;
        public DateTime StartDate;
        public string Description;
        public int WinnerId;
    }
}