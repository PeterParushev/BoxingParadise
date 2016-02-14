namespace BoxingParadiseBackend.DTOs
{
    public class BetDto
    {
        public int Id { get; set; }
        public int UserDtoId { get; set; }
        public int MatchDtoId { get; set; }
        public int BoxerDtoId { get; set; }
        public bool Canceled { get; set; }
    }
}