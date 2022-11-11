using ErrorOr;
using QuizGame.Application.Common.Interfaces.Authentication;
using QuizGame.Application.Common.Interfaces.Persistence;
using QuizGame.Domain.Entities;
using QuizGame.Domain.Common.Errors;

namespace QuizGame.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
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
        

        public ErrorOr<AuthenticationResult> Login(string email, string password)
        {
            //1. Валидация, что юзер существует
            if (_userRepository.GetUserByEmail(email) is not User user)
            {
                return Errors.Authentication.InvalidCredentials;
            }
            
            //2. Валидация, что пароль корректный
            if (user.Password != password)
            {
                return Errors.Authentication.InvalidCredentials;
            }
            
            //3. Создать JWT Token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token);
        }
    }
}