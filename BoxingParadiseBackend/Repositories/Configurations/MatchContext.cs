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
            HasRequired(x => x.BoxerOne);
            HasRequired(x => x.BoxerTwo);
            Property(x => x.StartDate).IsRequired();
            HasRequired(x => x.Venue);
            HasOptional(x => x.Winner);
            Property(x => x.Canceled);
            Property(x => x.Description).HasMaxLength(1000);
        }
    }
}