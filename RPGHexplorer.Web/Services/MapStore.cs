using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RPGHexplorer.Common.TileMaps;

namespace RPGHexplorer.Web.Services
{
    public class MapStore
    {
        private readonly ApiClient _apiClient;
        private readonly MapState _mapState;

        private List<Map> _maps = new List<Map>();

        public List<Map> GetMaps() => _maps;
        
        public event Action OnMapListChange;
        
        public MapStore(ApiClient apiClient, MapState mapState)
        {
            _apiClient = apiClient;
            _mapState = mapState;
        }

        public async Task ReloadMapsAsync()
        {
            _maps = await _apiClient.ListMapsAsync();

            MapListChanged();
        }
       
        
        public async Task<Map> CreateMapAsync(string name)
        {
            var map = await _apiClient.CreateMapAsync(name);

            _maps.Add(map);
            
            MapListChanged();

            return map;
        }

        public async Task LoadMapAsync(string mapId)
        {
            var map = _maps.Single(m => m.Id == mapId);

            await _mapState.LoadMapAsync(map);
        }
        
        public async Task DeleteMapAsync(string mapId)
        {
            var map = _maps.Single(m => m.Id == mapId);
            
            await _apiClient.DeleteMapAsync(mapId);

            _maps.Remove(map);
            
            MapListChanged();
        }
        
        private void MapListChanged()
        {
            _maps = _maps.OrderBy(m => m.Name).ToList();
            
            OnMapListChange?.Invoke();
        }

        
    }
}