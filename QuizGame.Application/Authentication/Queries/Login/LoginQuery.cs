using ErrorOr;
using MediatR;
using QuizGame.Application.Authentication.Common;

namespace QuizGame.Application.Authentication.Queries.Login;

public record LoginQuery(
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;