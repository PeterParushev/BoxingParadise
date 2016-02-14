using System;

namespace BoxingParadiseBackend.Models
{
    public class Match
    {
        public int Id { get; set; }
        public virtual Boxer BoxerOne { get; set; }
        public virtual Boxer BoxerTwo { get; set; }
        public virtual Venue Venue { get; set; }
        public DateTime StartDate { get; set; }
        public string Description { get; set; }
        public virtual Boxer Winner { get; set; }
        public bool Canceled { get; set; }
    }
}