using Microsoft.EntityFrameworkCore;
using RPGHexplorer.Lib.TileMaps;

namespace RPGHexplorer.Lib.DataBases
{
    public class MapDbContext : DbContext
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
    }
}