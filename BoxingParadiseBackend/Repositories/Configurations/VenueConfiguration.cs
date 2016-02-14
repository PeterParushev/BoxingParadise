using BoxingParadiseBackend.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BoxingParadiseBackend.Repositories.Configurations
{
    public class VenueConfiguration : EntityTypeConfiguration<Venue>
    {
        public VenueConfiguration()
        {
            ToTable("tVenue");
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Name).HasMaxLength(50).IsRequired();
            Property(x => x.Description).HasMaxLength(1000);
        }
    }
}