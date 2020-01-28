using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApiTESTEBACKENDRosembergue.Common
{
    public class MENUSConfiguracao : IEntityTypeConfiguration<Model.MENUS>
    {
        public void Configure(EntityTypeBuilder<Model.MENUS> builder)
        {
            builder
                .ToTable("MENUS");

            builder
                .Property(u => u.ID)
                .HasColumnName("ID");

            builder
               .Property(u => u.LABEL)
               .HasColumnName("LABEL");

            builder
               .Property(u => u.PARENT_ID)
               .HasColumnName("PARENT_ID");
        }
    }
}
