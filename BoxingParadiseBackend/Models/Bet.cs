namespace BoxingParadiseBackend.Models
{
    public class Bet
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Match Match { get; set; }
        public Boxer Boxer { get; set; }
        public bool Canceled { get; set; }
    }
}