using System.Collections.Generic;
using System.Threading.Tasks;
using RPGHexplorer.Common.TileMaps;

namespace RPGHexplorer.Lib.TileMaps.Repositories
{
    public interface IMapRepository
    {
        Task<List<Map>> GetAllAsync();

        Task<Map> GetAsync(string mapId);

        Task SaveAsync(Map map);

        Task DeleteAsync(string mapId);
    }
}