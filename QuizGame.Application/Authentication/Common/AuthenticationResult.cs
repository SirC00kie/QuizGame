using QuizGame.Domain.Entities;

namespace QuizGame.Application.Authentication.Common
{
    public record AuthenticationResult(
        User User,
        string Token);
}