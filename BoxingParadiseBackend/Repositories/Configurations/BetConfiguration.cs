using BoxingParadiseBackend.Models;
using System.Data.Entity.ModelConfiguration;

namespace BoxingParadiseBackend.Repositories.Configurations
{
    public class BetConfiguration : EntityTypeConfiguration<Bet>
    {
        public BetConfiguration()
        {
            ToTable("tBet");
            Property(x => x.BoxerId);
            Property(x => x.MatchId);
            Property(x => x.UserId);
            Property(x => x.Canceled);
        }
    }
}