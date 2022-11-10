using System;
using QuizGame.Application.Common.Interfaces.Authentication;

namespace QuizGame.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public AuthenticationResult Register(string name, string email, string password)
        {
            var userId = Guid.NewGuid();
            
            var token = _jwtTokenGenerator.GenerateToken(userId, name);
            
            return new AuthenticationResult(
                userId,
                name,
                email,
                token);
        }
        

        public AuthenticationResult Login(string email, string password)
        {
            return new AuthenticationResult(
                Guid.NewGuid(),
                "name",
                email,
                "token");
        }
    }
}