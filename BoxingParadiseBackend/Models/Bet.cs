namespace BoxingParadiseBackend.Models
{
    public class Bet
    {
        public int Id { get; set; }
        public virtual User User { get; set; }
        public virtual Match Match { get; set; }
        public virtual Boxer Boxer { get; set; }
        public bool Canceled { get; set; }
    }
}