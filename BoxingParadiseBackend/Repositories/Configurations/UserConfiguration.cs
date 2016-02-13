using BoxingParadiseBackend.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BoxingParadiseBackend.Repositories.Configurations
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            ToTable("tUser");
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Deleted);
            Property(x => x.FullName).HasMaxLength(50);
            Property(x => x.Password).HasMaxLength(50);
            Property(x => x.Rating);
            Property(x => x.Username).HasMaxLength(50);
        }
    }
}