using System.Collections.Generic;
using System.Threading.Tasks;

namespace RPGHexplorer.Lib.TileMaps.Repositories
{
    public interface IMapRepository
    {
        Task<List<Map>> GetMapsAsync();

        Task<Map> GetMapAsync(string mapId);

        Task SaveMapAsync(Map map);

        Task DeleteMapAsync(Map map);
    }
}