using BoxingParadiseBackend.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BoxingParadiseBackend.Repositories.Configurations
{
    public class MatchConfiguration : EntityTypeConfiguration<Match>
    {
        public MatchConfiguration()
        {
            ToTable("tMatch");
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.BoxerOneId).IsRequired();
            Property(x => x.BoxerTwoId).IsRequired();
            Property(x => x.StartDate).IsRequired();
            Property(x => x.VenueId).IsRequired();
            Property(x => x.WinnerId);
            Property(x => x.Canceled).IsRequired();
            Property(x => x.Description).HasMaxLength(1000);
        }
    }
}