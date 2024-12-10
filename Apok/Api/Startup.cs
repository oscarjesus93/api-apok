using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;

namespace Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private readonly IWebHostEnvironment _webHostEnvironment;

        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddMemoryCache();
            services.AddControllers();

            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = Configuration["Project:name"] + " " + Configuration["Project:Version"],
                    Version = "v1",
                    Description = Configuration["Project:description"],
                    License = new OpenApiLicense
                    {
                        Name = "MIT"
                    }
                });
            });

            services.AddCors(options =>
            {
                options.AddPolicy(name: "CorsPolicyDEV",
                                  policy =>
                                  {
                                      policy.WithOrigins("*").AllowAnyMethod().AllowAnyHeader();
                                  });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) 
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseCors("CorsPolicyDEV");
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
