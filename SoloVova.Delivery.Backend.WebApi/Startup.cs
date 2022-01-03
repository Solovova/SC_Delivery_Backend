using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SoloVova.Delivery.Backend.Application;
using SoloVova.Delivery.Backend.Application.Interfaces;
using SoloVova.Delivery.Backend.Application.Mapping;
using SoloVova.Delivery.Backend.Persistence;
using SoloVova.Delivery.Backend.WebApi.Middleware;

namespace SoloVova.Delivery.Backend.WebApi{
    public class Startup{
        public void ConfigureServices(IServiceCollection services){
            services.AddAutoMapper(config => {
                config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
                config.AddProfile(new AssemblyMappingProfile(typeof(IDeliveryDbContext).Assembly));
            });

            services.AddApplication();
            services.AddPersistence(Configuration);
            services.AddControllers();

            services.AddCors(options => {
                options.AddPolicy("AllowAll", policy => {
                    policy.AllowAnyHeader();
                    policy.AllowAnyMethod();
                    policy.AllowAnyOrigin();
                });
            });
            services.AddVersionedApiExplorer(options => options.GroupNameFormat = "'v'VVV");
            services.AddApiVersioning();
            // services.AddTransient<IConfigureOptions<SwaggerGenOptions>,
            //     ConfigureSwaggerOptions>();
            // services.AddSwaggerGen();
        }

        public IConfiguration Configuration{ get; }

        public Startup(IConfiguration configuration){
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env){
            if (env.IsDevelopment()){
                app.UseDeveloperExceptionPage();
            }
            
            // app.UseSwagger();
            //
            // app.UseSwaggerUI(options =>
            // {
            //     options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
            //     options.RoutePrefix = string.Empty;
            // });
            app.UseCustomExceptionHandler();
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseCors("AllowAll");
            app.UseApiVersioning();
            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}