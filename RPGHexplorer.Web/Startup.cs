using Microsoft.AspNetCore.Blazor.Builder;
using Microsoft.Extensions.DependencyInjection;
using RPGHexplorer.Common.Encounters;
using RPGHexplorer.Common.TileMaps;
using RPGHexplorer.Web.Services;

namespace RPGHexplorer.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<ITileMapService, TileMapApiClient>();
            services.AddSingleton<IEncounterService, EncounterApiClient>();
            
            services.AddSingleton<ToolState>();
            services.AddSingleton<MapState>();
            
            services.AddSingleton<TileClickService>();
            services.AddScoped<ModalService>();
        }

        public void Configure(IBlazorApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
