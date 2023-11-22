using System.Globalization;
using FCameraDesafioBackend.Application.UseCases.Auth.SignIn;
using FCameraDesafioBackend.Application.UseCases.Auth.SignIn.Commands;
using FCameraDesafioBackend.Application.UseCases.Auth.SignIn.Validations;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace FCameraDesafioBackend.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        services
            .AddValidators()
            .AddUseCases();
        
        return services;
    }

    private static IServiceCollection AddUseCases(this IServiceCollection services)
    {
        services.AddScoped<ISignInUseCase, SignInUseCase>();
        return services;
    }

    private static IServiceCollection AddValidators(this IServiceCollection services)
    {
        ValidatorOptions.Global.LanguageManager.Culture = new CultureInfo("en");

        services.AddScoped<IValidator<SignInCommand>, SignInCommandValidator>();
        return services;
    }
}