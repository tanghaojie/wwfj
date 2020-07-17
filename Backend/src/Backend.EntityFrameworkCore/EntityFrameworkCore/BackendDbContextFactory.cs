using Backend.Configuration;
using Backend.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Backend.EntityFrameworkCore
{
    /* This class is needed to run EF Core PMC commands. Not used anywhere else */
    public class BackendDbContextFactory : IDesignTimeDbContextFactory<BackendDbContext>
    {
        public BackendDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<BackendDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder(), null, false);

            DbContextOptionsConfigurer.Configure(
                builder,
                configuration.GetConnectionString(BackendConsts.ConnectionStringName)
            );

            return new BackendDbContext(builder.Options);
        }
    }
}