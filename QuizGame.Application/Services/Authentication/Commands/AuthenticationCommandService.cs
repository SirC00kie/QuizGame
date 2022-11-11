using ErrorOr;
using QuizGame.Application.Common.Interfaces.Authentication;
using QuizGame.Application.Common.Interfaces.Persistence;
using QuizGame.Application.Services.Authentication.Common;
using QuizGame.Domain.Common.Errors;
using QuizGame.Domain.Entities;

namespace QuizGame.Application.Services.Authentication.Commands
{
    public class AuthenticationCommandService : IAuthenticationCommandService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public AuthenticationCommandService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }

        public ErrorOr<AuthenticationResult> Register(string name, string email, string password)
        {
            //1. Валидация, что юзера еще нет
            if (_userRepository.GetUserByEmail(email) is not null)
            {
                return Errors.User.DuplicateEmail;
            }
            
            //2. Создать юзера (генерация уникального ид) и добавление в БД
            var user = new User
            {
                Name = name,
                Email = email,
                Password = password
            };
            _userRepository.Add(user);
            
            //3. Создать JWT Token
            var token = _jwtTokenGenerator.GenerateToken(user);
            
            return new AuthenticationResult(
                user,
                token);
        }
        
    }
}