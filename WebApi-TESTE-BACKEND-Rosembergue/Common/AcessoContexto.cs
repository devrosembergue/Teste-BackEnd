using Microsoft.EntityFrameworkCore;
using WebApiTESTEBACKENDRosembergue.Model;

namespace WebApiTESTEBACKENDRosembergue.Common
{
    public class AcessoContexto : DbContext
    {
        public DbSet<USERS> USERS { get; set; }
        public DbSet<MENUS> MENUS { get; set; }
        public DbSet<MENUS_USERS> MENUS_USERS { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=Teste;Trusted_connection=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new USERSConfiguracao());
            modelBuilder.ApplyConfiguration(new MENUSConfiguracao());
            modelBuilder.ApplyConfiguration(new MENUS_USERSConfiguracao());
        }
    }
}
