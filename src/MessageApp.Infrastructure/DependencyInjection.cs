using MessageApp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
namespace MessageApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
       this IServiceCollection services,
       ConfigurationManager configuration)
        {
            services
                .AddPersistance();

            return services;
        }
        public static IServiceCollection AddPersistance(
       this IServiceCollection services)
        {
            services.AddDbContext<MessageAppDbContext>(options =>
                options.UseSqlServer("Server=DESKTOP-HIUFAFC\\JOELFERREIRA2022;Initial Catalog=MessageApp;Persist Security Info=False;User ID=sa;Password=innux123+;MultipleActiveResultSets=False;Encrypt=false;TrustServerCertificate=False;"));

            return services;
        }
    }
}
