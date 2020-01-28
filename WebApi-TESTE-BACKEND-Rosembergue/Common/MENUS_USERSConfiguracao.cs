using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApiTESTEBACKENDRosembergue.Common
{
    public class MENUS_USERSConfiguracao : IEntityTypeConfiguration<Model.MENUS_USERS>
    {
        public void Configure(EntityTypeBuilder<Model.MENUS_USERS> builder)
        {
            builder
                .ToTable("MENUS_USERS");

            builder
                .Property(u => u.MENU_ID)
                .HasColumnName("MENU_ID");

            builder
               .Property(u => u.USER_ID)
               .HasColumnName("USER_ID");
        }
    }
}
