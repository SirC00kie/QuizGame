using ErrorOr;
using MediatR;
using QuizGame.Application.Authentication.Common;
using QuizGame.Application.Common.Interfaces.Authentication;
using QuizGame.Application.Common.Interfaces.Persistence;
using QuizGame.Domain.Common.Errors;
using QuizGame.Domain.Entities;

namespace QuizGame.Application.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        //1. Валидация, что юзера еще нет
        if (_userRepository.GetUserByEmail(command.Email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }
            
        //2. Создать юзера (генерация уникального ид) и добавление в БД
        var user = new User
        {
            Name = command.Name,
            Email =command.Email,
            Password = command.Password
        };
        _userRepository.Add(user);
            
        //3. Создать JWT Token
        var token = _jwtTokenGenerator.GenerateToken(user);
            
        return new AuthenticationResult(
            user,
            token);
    }
}