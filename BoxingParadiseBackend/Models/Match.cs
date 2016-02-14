using System;

namespace BoxingParadiseBackend.Models
{
    public class Match
    {
        public int Id { get; set; }
        public Boxer BoxerOne { get; set; }
        public Boxer BoxerTwo { get; set; }
        public Venue Venue { get; set; }
        public DateTime StartDate { get; set; }
        public string Description { get; set; }
        public Boxer Winner { get; set; }
        public bool Canceled { get; set; }
    }
}