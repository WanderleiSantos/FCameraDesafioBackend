using FCameraDesafioBackend.Application.Shared.Models;
using FCameraDesafioBackend.Application.UseCases.Auth.SignIn.Commands;

namespace FCameraDesafioBackend.Application.UseCases.Auth.SignIn;

public interface ISignInUseCase
{
    Task<Output> ExecuteAsync(SignInCommand command, CancellationToken cancellationToken);
}