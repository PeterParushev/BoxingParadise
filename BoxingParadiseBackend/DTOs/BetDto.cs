namespace BoxingParadiseBackend.DTOs
{
    public class BetDto
    {
        public int Id { get; set; }
        public UserDto UserDto { get; set; }
        public MatchDto MatchDto { get; set; }
        public BoxerDto BoxerDto { get; set; }
        public bool Canceled { get; set; }
    }
}