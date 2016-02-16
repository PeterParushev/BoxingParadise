using BoxingParadiseBackend.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BoxingParadiseBackend.Repositories.Configurations
{
    public class LoginConfiguration : EntityTypeConfiguration<Login>
    {
        public LoginConfiguration()
        {
            ToTable("tLogin");
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.ExpiryDate).IsRequired();
            Property(x => x.Key).IsRequired().HasMaxLength(10);
            Property(x => x.IsExpired).IsRequired();
        }
    }
}