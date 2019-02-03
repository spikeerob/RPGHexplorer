using System.IO;
using Microsoft.AspNetCore.Blazor.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RPGHexplorer.Lib.DataBases;
using RPGHexplorer.Lib.TileMaps.Repositories;
using RPGHexplorer.Lib.TileMaps.Services;

namespace Web
{
    public class Startup
    {
        static IConfiguration Configuration { get; set; }

        public Startup(IConfiguration config)
        {
            Configuration = config;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MapDbContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("MapDatabase")));
            
            services.AddSingleton<IMapRepository, DbMapRepository>();
            services.AddSingleton<ITileRepository, DbTileRepository>();

            services.AddSingleton<TileMapService, TileMapService>();
        }

        public void Configure(IBlazorApplicationBuilder app)
        {
            app.AddComponent<App>("app");
        }
    }
}
