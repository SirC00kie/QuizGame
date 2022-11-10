using System;
using QuizGame.Application.Common.Interfaces.Authentication;
using QuizGame.Application.Common.Interfaces.Persistence;
using QuizGame.Domain.Entities;

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

        public AuthenticationResult Register(string name, string email, string password)
        {
            //1. Валидация, что юзера еще нет
            if (_userRepository.GetUserByEmail(email) is not null)
            {
                throw new Exception("User with given email alredy exists");
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
        

        public AuthenticationResult Login(string email, string password)
        {
            //1. Валидация, что юзер существует
            if (_userRepository.GetUserByEmail(email) is not User user)
            {
                throw new Exception("User with given email does not exist");
            }
            
            //2. Валидация, что пароль корректный
            if (user.Password != password)
            {
                throw new Exception("Invalid password");
            }
            
            //3. Создать JWT Token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(
                user,
                token);
        }
    }
}