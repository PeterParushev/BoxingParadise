using System;

namespace BoxingParadiseBackend.Models
{
    public class Match
    {
        public int BoxerOneId;
        public int BoxerTwoId;
        public int VenueId;
        public DateTime Date;
        public string Description;
        public int WinnerId;
    }
}
