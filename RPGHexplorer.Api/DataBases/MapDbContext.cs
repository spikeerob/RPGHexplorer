using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RPGHexplorer.Common.TileMaps;
using RPGHexplorer.Lib.Repositories;

namespace RPGHexplorer.Api.DataBases
{
    public class MapDbContext : DbContext, IUnitOfWork
    {
        public MapDbContext(DbContextOptions<MapDbContext> options)
            : base(options)
        { }

        public DbSet<Map> Maps { get; set; }
        public DbSet<Tile> Tiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tile>()
                .HasKey(a => new { a.MapId, a.Id });
        }
        
        public async Task SaveAsync()
        {
            await SaveChangesAsync();
        }
    }
}