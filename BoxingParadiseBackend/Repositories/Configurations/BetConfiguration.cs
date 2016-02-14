using BoxingParadiseBackend.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BoxingParadiseBackend.Repositories.Configurations
{
    public class BetConfiguration : EntityTypeConfiguration<Bet>
    {
        public BetConfiguration()
        {
            ToTable("tBet");
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.BoxerId).IsRequired().HasColumnName("Fk_tBoxer_PredictionId");
            Property(x => x.MatchId).IsRequired().HasColumnName("Fk_tMatch_MatchId");
            Property(x => x.UserId).IsRequired().HasColumnName("Fk_tUser_UserId");
            Property(x => x.Canceled);
        }
    }
}