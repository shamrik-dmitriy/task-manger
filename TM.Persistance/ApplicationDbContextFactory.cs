using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace TM.Persistance;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var basePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "TM.WebApi");

        var config = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json", false)
            .Build();
        
        var connectionString = config.GetConnectionString("DefaultConnection");
        var builder = new DbContextOptionsBuilder<ApplicationDbContext>();

        builder.UseSqlite(connectionString);
        
        return new ApplicationDbContext(builder.Options);
    }
}