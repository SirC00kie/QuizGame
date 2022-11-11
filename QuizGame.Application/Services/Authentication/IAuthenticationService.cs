
using ErrorOr;

namespace QuizGame.Application.Services.Authentication
{
    public interface IAuthenticationService
    {
        ErrorOr<AuthenticationResult> Register(string name, string email, string password);
        ErrorOr<AuthenticationResult> Login(string email, string password);
    }
}