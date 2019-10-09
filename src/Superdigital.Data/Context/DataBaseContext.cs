using System.IO;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Superdigital.CoreShared.Data;

namespace Superdigital.Data.Context
{
    public class DataBaseContext : DbContext, IUnitOfWork
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // na versão EFCore 2.2 saiu uma nova feature que resolve tudo isso, ficou mais clean, pouco código e tudo resolvido, 
            //veja que agora tudo faz mais sentido, graças ao ApplyConfigurationsFromAssembly.
            // 
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataBaseContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            optionsBuilder.UseSqlServer(config.GetConnectionString("SqlConnection"));
        }
        public async Task<bool> CommitAsync()
        {
            return await SaveChangesAsync().ConfigureAwait(false) > 0;
        }
    }
}