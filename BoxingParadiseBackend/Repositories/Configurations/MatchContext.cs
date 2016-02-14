using BoxingParadiseBackend.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BoxingParadiseBackend.Repositories.Configurations
{
    public class MatchContext : EntityTypeConfiguration<Match>
    {
        public MatchContext()
        {
            ToTable("tMatch");
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.BoxerOneId).HasColumnName("Fk_tBoxer_BoxerOneId").IsRequired();
            Property(x => x.BoxerTwoId).HasColumnName("Fk_tBoxer_BoxerTwoId").IsRequired();
            Property(x => x.StartDate).IsRequired();
            Property(x => x.VenueId).HasColumnName("Fk_tVenue_VenueId").IsRequired();
            Property(x => x.WinnerId).HasColumnName("Fk_tBoxer_WinnerId");
            Property(x => x.Canceled);
            Property(x => x.Description).HasMaxLength(1000);
        }
    }
}