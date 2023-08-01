using ApiUserCrud.BusinessLayer.Services;
using ApiUserCrud.DataAccess.Context;
using ApiUserCrud.DataAccess.Repositories;
using ApiUserCrud.GrpcService.Services;
using Microsoft.EntityFrameworkCore.Design;

namespace ApiUserCrud.GrpcService
{
    public class Startup
    {
        public IConfiguration configRoot
        {
            get;
        }
        public Startup(IConfiguration configuration)
        {
            configRoot = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            string dbConfigurationString = configRoot.GetConnectionString("db") ?? "";

            services.AddSingleton<IDesignTimeDbContextFactory<ApiUserCrudDBContext>>(new ApiUserCrudDBContextFactory(dbConfigurationString));
            services.AddSingleton<IUserRepository, UserRepository>();
            services.AddSingleton<IUserService, UserService>();
            services.AddGrpc();
        }
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<UserGrpcService>();
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
                });
            });
            app.Run();
        }
    }
}
