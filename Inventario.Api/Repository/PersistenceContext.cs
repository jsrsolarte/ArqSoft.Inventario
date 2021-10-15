using System.Threading.Tasks;
using Inventario.Api.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Inventario.Api.Repository
{
    public class PersistenceContext : DbContext
    {
        private readonly IConfiguration _config;

        public PersistenceContext(DbContextOptions<PersistenceContext> options, IConfiguration config) : base(options)
        {
            _config = config;
        }

        public async Task CommitAsync() => _ = await SaveChangesAsync().ConfigureAwait(false);

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("inventario");
            modelBuilder.Entity<Producto>();

            base.OnModelCreating(modelBuilder);
        }
    }
}