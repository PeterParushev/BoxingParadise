using BoxingParadiseBackend.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BoxingParadiseBackend.Repositories.Configurations
{
    public class AdministratorConfiguration : EntityTypeConfiguration<Administrator>
    {
        public AdministratorConfiguration()
        {
            ToTable("tAdministrator");
            Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(e => e.AdminKey).HasMaxLength(30).IsRequired();
        }
    }
}