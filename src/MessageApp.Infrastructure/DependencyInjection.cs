using MessageApp.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using MessageApp.Application.Common.Contracts;
using MessageApp.Infrastructure.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using MessageApp.Infrastructure.Identity.Services;
using MessageApp.Infrastructure.Identity.Entities;
using MessageApp.Domain.Aggregates.ConversationAggregate.Repository;
using MessageApp.Infrastructure.Persistence.Repositories;
using MessageApp.Infrastructure.Tenant;

namespace MessageApp.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
       this IServiceCollection services,
       ConfigurationManager configuration)
        {
            services
                .AddPersistance().AddAuth(configuration);

            return services;
        }
        public static IServiceCollection AddPersistance(
       this IServiceCollection services)
        {
            services.AddDbContext<MessageAppDbContext>(options =>
                options.UseSqlServer("Server=DESKTOP-HIUFAFC\\JOELFERREIRA2022;Initial Catalog=MessageApp;Persist Security Info=False;User ID=sa;Password=innux123+;MultipleActiveResultSets=False;Encrypt=false;TrustServerCertificate=False;"));
            services.AddScoped<IConversationRepository, ConversationRepository>();
            services.AddScoped<ITenantService, TenantService>();
            return services;
        }
        public static IServiceCollection AddAuth(
        this IServiceCollection services,
        ConfigurationManager configuration)
        {
            services.AddDbContext<MessageAppIdentityContext>(options =>
                options.UseSqlServer("Server=DESKTOP-HIUFAFC\\JOELFERREIRA2022;Initial Catalog=MessageAppIdentity;Persist Security Info=False;User ID=sa;Password=innux123+;MultipleActiveResultSets=False;Encrypt=false;TrustServerCertificate=False;"));
            services.AddIdentity<User, Role>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddDefaultUI()
            .AddDefaultTokenProviders()
            .AddEntityFrameworkStores<MessageAppIdentityContext>();
            services.Configure<IdentityOptions>(options =>
            {
                options.User.AllowedUserNameCharacters =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@";
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.User.RequireUniqueEmail = true;
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-.`~ ";
            });
            var jwtSettings = configuration.GetSection("JwtSettings");
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings.GetSection("validIssuer").Value,
                    ValidAudience = jwtSettings.GetSection("validAudience").Value,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.GetSection("securityKey").Value))
                };
            });
            services.AddScoped<ITokenClaimService, TokenClaimService>();
            services.AddScoped<IIdentityService, IdentityService>();
            return services;

        }
    }
}
