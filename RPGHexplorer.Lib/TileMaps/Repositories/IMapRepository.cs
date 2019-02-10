using System.Collections.Generic;
using System.Threading.Tasks;
using RPGHexplorer.Common.TileMaps;

namespace RPGHexplorer.Lib.TileMaps.Repositories
{
    public interface IMapRepository
    {
        Task<List<Map>> GetMapsAsync();

        Task<Map> GetMapAsync(string mapId);

        Task SaveMapAsync(Map map);

        Task DeleteMapAsync(string mapId);
    }
}