using System;
using System.Collections.Generic;

namespace BoxingParadiseBackend.Models
{
    public class Match
    {
        public Match()
        {
            Boxers = new HashSet<Boxer>();
        }

        public int Id { get; set; }
        public virtual Boxer BoxerOne { get; set; }
        public virtual Boxer BoxerTwo { get; set; }
        public virtual Venue Venue { get; set; }
        public DateTime StartDate { get; set; }
        public string Description { get; set; }
        public virtual Boxer Winner { get; set; }
        public bool Canceled { get; set; }

        public virtual HashSet<Boxer> Boxers { get; set; }
    }
}