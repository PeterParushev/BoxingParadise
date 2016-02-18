namespace BoxingParadiseBackend.Models
{
    public class Bet
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MatchId { get; set; }
        public int BoxerId { get; set; }
        public bool Canceled { get; set; }

        public virtual User User { get; set; }
        public virtual Boxer Boxer { get; set; }
        public virtual Match Match { get; set; }
    }
}