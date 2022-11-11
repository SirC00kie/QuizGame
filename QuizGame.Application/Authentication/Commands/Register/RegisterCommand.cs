using ErrorOr;
using MediatR;
using QuizGame.Application.Authentication.Common;

namespace QuizGame.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string Name,
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;