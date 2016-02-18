using System;
using System.Collections.Generic;

namespace BoxingParadiseBackend.Models
{
    public class Match
    {
        public int Id { get; set; }
        public int BoxerOneId { get; set; }
        public int BoxerTwoId { get; set; }
        public int VenueId { get; set; }
        public DateTime StartDate { get; set; }
        public string Description { get; set; }
        public int? WinnerId { get; set; }
        public bool Canceled { get; set; }

        public virtual Boxer BoxerOne { get; set; }
        public virtual Boxer BoxerTwo { get; set; }
        public virtual Venue Venue { get; set; }
        public virtual Boxer Winner { get; set; }
    }
}