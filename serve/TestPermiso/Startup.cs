using GenericApi.Bl.Config;
using GenericApi.Config;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace TestPermiso
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            #region CORS

            services.AddCors(options =>
            {
                options.AddPolicy("MainPolicy",
                      builder =>
                      {
                          builder
                                 .AllowAnyHeader()
                                 .AllowAnyMethod()
                                 .AllowCredentials();

                          //TODO: remove this line for production
                          builder.SetIsOriginAllowed(x => true);
                      });
            });

            #endregion

            #region External Dependencies

            services.ConfigSqlServerDbContext(Configuration.GetConnectionString("DefaultConnection"));
            services.AddControllers(options => options.EnableEndpointRouting = false)
                .ConfigFluentValidation();
            services.ConfigAutoMapper();
            services.ConfigSerilog();

            #endregion

            #region API Libraries

            services.ConfigOData();

            #endregion

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

            app.UseCors("MainPolicy");

        }
    }
}
