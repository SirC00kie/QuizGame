using QuizGame.Domain.Entities;

namespace QuizGame.Application.Services.Authentication.Common
{
    public record AuthenticationResult(
        User User,
        string Token);
}