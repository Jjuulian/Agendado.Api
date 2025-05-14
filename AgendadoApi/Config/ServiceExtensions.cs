using Microsoft.EntityFrameworkCore;
using AgendadoApi.Data;
using AgendadoApi.Services.Implementations;
using AgendadoApi.Services.Interfaces;

namespace AgendadoApi.Config
{
    public static class ServiceExtensions
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AgendaDbContext>(options =>
                options.UseMySql(
                    configuration.GetConnectionString("DefaultConnection"), 
                    ServerVersion.AutoDetect(configuration.GetConnectionString("DefaultConnection"))
                )
            );

            services.AddScoped<IUserService, UserService>();
        }
    }
}
