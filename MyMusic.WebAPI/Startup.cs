using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MyMusic.Business.Concrete;
using MyMusic.Business.Interfaces;
using MyMusic.DataAccess.Concrete.Context;
using MyMusic.DataAccess.Concrete.Repositories;
using MyMusic.DataAccess.Interfaces;
using MyMusic.DataAccess.UnitOfWork;
using Swashbuckle.AspNetCore.Swagger;

namespace MyMusic.WebAPI
{
    public class Startup
    {
        private readonly IConfiguration _config;
        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddDbContext<MMDbContext>();
            services.AddScoped<IUOW, UOW>();
            services.AddScoped<IMusicService, MusicService>();
            services.AddScoped<IArtistService, ArtistService>();
            services.AddScoped(typeof(IGenericService<>), (typeof(GenericService<>)));


            services.AddControllers();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "My Music", Version = "v1" });
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.RoutePrefix = "";
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Music V1");
                });
            }

            app.UseRouting();

            app.UseEndpoints(op =>
            {
                op.MapDefaultControllerRoute();
                });
         
        }
    }
}
