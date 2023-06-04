using Infrastructure.Persistence.Configurations.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Persistence.Configurations.Context;

public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 27));

        optionsBuilder.UseMySql("Server=141.98.112.67;Port=7002;Database=sevval_barin_final_project;Uid=sevval_barin;Pwd=g6Hw2X2PNa7yb58hJEo3rYGOR;", serverVersion);

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}