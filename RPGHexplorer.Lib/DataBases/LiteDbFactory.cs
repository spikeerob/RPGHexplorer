using System.Data;
using LiteDB;
using RPGHexplorer.Common.TileMaps;

namespace RPGHexplorer.Lib.DataBases
{
    public class LiteDbFactory
    {
        private readonly string _connectionString;

        public LiteDbFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public LiteDatabase GetDb()
        {
            var db = new LiteDatabase(_connectionString);

            
            if (db.Engine.UserVersion == 0)
            {
                var tiles = db.GetCollection<Tile>(LiteDbTables.Tiles);
                tiles.EnsureIndex(t => t.MapId);
                tiles.EnsureIndex(t => t.TileId);

            }

            return db;
        }
    }
}