using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApiTESTEBACKENDRosembergue.Common
{
    public class USERSConfiguracao : IEntityTypeConfiguration<Model.USERS>
    {
        public void Configure(EntityTypeBuilder<Model.USERS> builder)
        {
            builder
                .ToTable("USERS");

            builder
                .Property(u => u.ID)
                .HasColumnName("ID");

            builder
               .Property(u => u.NAME)
               .HasColumnName("NAME");
        }
    }
}
