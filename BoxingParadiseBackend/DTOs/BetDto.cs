namespace BoxingParadiseBackend.DTOs
{
    public class BetDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MatchId { get; set; }
        public int BoxerId { get; set; }
        public bool Canceled { get; set; }
    }
}