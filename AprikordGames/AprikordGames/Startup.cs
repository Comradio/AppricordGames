using AprikordGames.Data;
using AprikordGames.Interfaces;
using AprikordGames.Models;
using AprikordGames.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AprikordGames
{
    public class Startup
    {
        private IConfigurationRoot _confstring;
        public Startup(IWebHostEnvironment HostEnvironment)
        {
            _confstring = new ConfigurationBuilder().SetBasePath(HostEnvironment.ContentRootPath).AddJsonFile("dbsettings.json").Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddDbContext<GameContext>(options => options.UseSqlServer(_confstring.GetConnectionString("DefaultConnection")));
            services.AddTransient<IGameService, GameService>();
            services.AddTransient<IGenreService, GenreService>();
            services.AddTransient<IDeveloperStudioService, DeveloperStudioService>();

            services.AddScoped<DeveloperStudioService>();
            services.AddScoped<GameService>();
            services.AddScoped<GenreService>();
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "AprikordGames", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "AprikordGames v1"));

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            using (var Scope = app.ApplicationServices.CreateScope())
            {
                GameContext gameContext = Scope.ServiceProvider.GetRequiredService<GameContext>();
                DbInitializer.Initialize(gameContext);
            }
        }

        // connect http://localhost:5000
        // ui
    }
}
