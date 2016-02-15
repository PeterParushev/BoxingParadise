using BoxingParadiseBackend.Models;
using System.Data.Entity.ModelConfiguration;

namespace BoxingParadiseBackend.Repositories.Configurations
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            ToTable("tUser");
            Property(x => x.Deleted).IsRequired();
            Property(x => x.FullName).HasMaxLength(50).IsRequired();
            Property(x => x.Password).HasMaxLength(50).IsRequired();
            Property(x => x.Rating);
            HasKey(x => x.Username);
        }
    }
}