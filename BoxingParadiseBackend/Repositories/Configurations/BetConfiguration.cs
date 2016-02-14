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
            HasRequired(x => x.Boxer);
            HasRequired(x => x.Match);
            HasRequired(x => x.User);
            Property(x => x.Canceled);
        }
    }
}