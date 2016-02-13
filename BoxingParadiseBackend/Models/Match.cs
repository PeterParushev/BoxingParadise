using System;

namespace BoxingParadiseBackend.Models
{
    public class Match
    {
        public int BoxerOneId;
        public int BoxerTwoId;
        public int VenueId;
        public DateTime StartDate;
        public string Description;
        public int WinnerId;
        public bool Canceled;
    }
}