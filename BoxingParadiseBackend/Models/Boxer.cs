using System.Collections.Generic;

namespace BoxingParadiseBackend.Models
{
    public class Boxer
    {
        public Boxer()
        {
            Bets = new HashSet<Bet>();
            Matches = new HashSet<Match>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool Deleted { get; set; }

        public virtual HashSet<Bet> Bets { get; set; }
        public virtual HashSet<Match> Matches { get; set; }
    }
}