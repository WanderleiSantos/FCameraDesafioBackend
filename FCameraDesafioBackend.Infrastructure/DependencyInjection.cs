using System.Text;
using FCameraDesafioBackend.Application.Shared.Authentication;
using FCameraDesafioBackend.Domain.Interfaces.Persistence.Repositories;
using FCameraDesafioBackend.Infrastructure.Authentication;
using FCameraDesafioBackend.Infrastructure.Persistence;
using FCameraDesafioBackend.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace FCameraDesafioBackend.Infrastructure;

public static class DependencyInjection
{
    private const string ConnectionStringSection = "DbContext";

    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        if (services is null) throw new ArgumentNullException(nameof(services));

        services
            .AddAuth(configuration)
            .AddContexts(configuration)
            .AddPersistence();

        return services;
    }

    private static IServiceCollection AddContexts(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DefaultDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString(ConnectionStringSection)));

        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);

        services.AddScoped<DefaultDbContext>();

        return services;
    }

    private static IServiceCollection AddPersistence(this IServiceCollection services)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        return services;
    }

    private static IServiceCollection AddAuth(this IServiceCollection services, IConfiguration configuration)
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, jwtSettings);
        services.AddSingleton(Options.Create(jwtSettings));

        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

        services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Secret)),
                };
            });

        return services;
    }
}