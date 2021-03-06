using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Tasnim.Data.Contexts;
using Tasnim.Data.Repositories.Interfaces;
using Tasnim.Data.Repositories.Services;
using Tasnim.Service.Helpers;
using Tasnim.Service.Interfaces;
using Tasnim.Service.Mappers;
using Tasnim.Service.Services;

namespace Tasnim.Api
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


            services.AddDbContext<TasnimDbContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("TasnimDb"));
            });

            services.AddControllers().AddJsonOptions(
                config => config
                .JsonSerializerOptions
                .IgnoreReadOnlyProperties = true);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Tasnim.Api", Version = "v1" });
            });
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddHttpContextAccessor();

            // Mapper services
            services.AddAutoMapper(typeof(MapperProfile));


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment() || env.IsProduction())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Tasnim.Api v1"));
            }

            if (app.ApplicationServices.GetService<IHttpContextAccessor>() != null)
            {
                HttpContextHelper.Accessor = app.ApplicationServices.GetRequiredService<IHttpContextAccessor>();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
