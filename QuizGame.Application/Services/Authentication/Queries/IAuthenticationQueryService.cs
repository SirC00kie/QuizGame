using ErrorOr;
using QuizGame.Application.Services.Authentication.Common;

namespace QuizGame.Application.Services.Authentication.Queries
{
    public interface IAuthenticationQueryService
    {
        ErrorOr<AuthenticationResult> Login(string email, string password);
    }
}