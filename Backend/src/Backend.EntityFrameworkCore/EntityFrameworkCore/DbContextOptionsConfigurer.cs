using Microsoft.EntityFrameworkCore;

namespace Backend.EntityFrameworkCore
{
    public static class DbContextOptionsConfigurer
    {
        public static void Configure(
            DbContextOptionsBuilder<BackendDbContext> dbContextOptions,
            string connectionString
            )
        {
            /* This is the single point to configure DbContextOptions for BackendDbContext */
            dbContextOptions.UseNpgsql(connectionString);
        }
    }
}
