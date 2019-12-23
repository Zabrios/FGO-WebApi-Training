using AutoMapper;
using FGO.WebApi.Domain.Contracts.Services.Servant;
using FGO.WebApi.Domain.Services.Servant;
using FGO.WebApi.Infrastructure;
using FGO.WebApi.Infrastructure.Contracts;
using FGO.WebApi.Persistence;
using FGO.WebApi.Persistence.Context;
using FGO.WebApi.Persistence.Contracts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Swashbuckle.AspNetCore.Swagger;

namespace FGO.WebApi.Training
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
            services.AddControllers();
            services.AddScoped<IFGOContext, FGOContext>();

            services.AddAutoMapper(typeof(Startup));
            services.AddDbContext<FGOContext>(options =>
            {
                var connString = Configuration["ConnectionString"];
                options.UseSqlServer(connString, b => b.MigrationsAssembly("FGO.WebApi.Training"));
                options.EnableDetailedErrors();
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IServantsService, ServantsService>();
            services.AddScoped<IServantsRepository, ServantsRepository>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "FGO Web API", Version ="v1"});
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "FGO Web API v1");
                c.RoutePrefix = string.Empty;
            });

        }
    }
}
