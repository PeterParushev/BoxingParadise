using System.Collections.Generic;

namespace BoxingParadiseBackend.Models
{
    public class Venue
    {
        public Venue()
        {
            Matches = new HashSet<Match>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Deleted { get; set; }

        public virtual HashSet<Match> Matches { get; set; }
    }
}