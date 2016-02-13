using BoxingParadiseBackend.Models;
using System.Data.Entity.ModelConfiguration;

namespace BoxingParadiseBackend.Repositories.Configurations
{
    public class MatchContext : EntityTypeConfiguration<Match>
    {
        public MatchContext()
        {
            ToTable("tMatch");
            Property(x => x.BoxerOneId).HasColumnName("Fk_tBoxer_BoxerOneId");
            Property(x => x.BoxerTwoId).HasColumnName("Fk_tBoxer_BoxerTwoId");
            Property(x => x.StartDate);
            Property(x => x.VenueId).HasColumnName("Fk_tVenue_VenueId");
            Property(x => x.WinnerId).HasColumnName("Fk_tBoxer_WinnerId");
            Property(x => x.Canceled);
            Property(x => x.Description).HasMaxLength(1000);
        }
    }
}