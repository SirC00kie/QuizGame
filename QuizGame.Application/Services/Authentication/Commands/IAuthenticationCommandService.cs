using ErrorOr;
using QuizGame.Application.Services.Authentication.Common;

namespace QuizGame.Application.Services.Authentication.Commands
{
    public interface IAuthenticationCommandService
    {
        ErrorOr<AuthenticationResult> Register(string name, string email, string password);
    }
}