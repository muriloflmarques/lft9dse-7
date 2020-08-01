using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Smc.Infra.Data
{
    public class ScmDbContextFactory : IDesignTimeDbContextFactory<ScmDbContext>
    {
        public ScmDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ScmDbContext>();
            optionsBuilder.UseSqlServer("server=localhost;database=SCMdb_Dev;User Id=sa;Password=d3&j*D1AlC#54jFbo)fw@58lG;");

            return new ScmDbContext(optionsBuilder.Options);
        }
    }
}