using System.Threading.Tasks;
using RPGHexplorer.Common.TileMaps;

namespace RPGHexplorer.Web.Services
{
    public class TileClickService
    {
        private readonly ToolState _toolState;
        private readonly MapState _mapState;

        public TileClickService(ToolState toolState, MapState mapState)
        {
            _toolState = toolState;
            _mapState = mapState;
        }

        public async Task ClickedAsync(string tileKey)
        {
            if (_toolState.IsTerrain)
            {
                await _mapState.MutateTileAsync(tileKey, t =>
                {
                    t.TerrainTypeId = _toolState.CurrentTerrainTypeId;
                });
            }
        }

        public async Task OnMouseOverAsync(string tileKey)
        {
            if (_toolState.IsDragging && _toolState.IsTerrain)
            {
                var tile = _mapState.GetTile(tileKey);

                System.Console.WriteLine($"drag {tileKey}");
                
                if (tile?.TerrainTypeId != _toolState.CurrentTerrainTypeId)
                {
                    await _mapState.MutateTileAsync(tileKey, t =>
                    {
                        t.TerrainTypeId = _toolState.CurrentTerrainTypeId;
                    });
                }
            }
        }
    }
}