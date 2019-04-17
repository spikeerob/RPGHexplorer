using System.Linq;
using System.Net.Mime;
using Microsoft.AspNetCore.Blazor.Server;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RPGHexplorer.Common.Encounters;
using RPGHexplorer.Common.Terrain;
using RPGHexplorer.Common.TileMaps;
using RPGHexplorer.Lib.DataBases;
using RPGHexplorer.Lib.Encounters;
using RPGHexplorer.Lib.Encounters.Repositories;
using RPGHexplorer.Lib.Terrain;
using RPGHexplorer.Lib.Terrain.Repositories;
using RPGHexplorer.Lib.TileMaps.Repositories;
using RPGHexplorer.Lib.TileMaps.Services;

namespace RPGHexplorer.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            
            services.AddResponseCompression(options =>
            {
                options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[]
                {
                    MediaTypeNames.Application.Octet,
                    WasmMediaTypeNames.Application.Wasm,
                });
            });

            services.AddSingleton<LiteDbFactory>(
                new LiteDbFactory(Configuration.GetConnectionString("MapDatabase")));

            services.AddSingleton<IMapRepository, DbMapRepository>();
            services.AddSingleton<ITileRepository, DbTileRepository>();
            services.AddSingleton<IEncounterRepository, DbEncounterRepository>();
            services.AddSingleton<ITerrainTypeRepository, TerrainTypeRepository>();

            services.AddSingleton<ITileMapService, TileMapService>();
            services.AddSingleton<IEncounterService, EncounterService>();
            services.AddSingleton<ITerrainService, TerrainService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseResponseCompression();
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            //app.UseHttpsRedirection();
            app.UseMvc();
            
            app.UseBlazor<Web.Startup>();
        }
    }
}