using ErrorOr;
using MediatR;
using QuizGame.Application.Authentication.Common;
using QuizGame.Application.Common.Interfaces.Authentication;
using QuizGame.Application.Common.Interfaces.Persistence;
using QuizGame.Domain.Common.Errors;
using QuizGame.Domain.Entities;

namespace QuizGame.Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        //1. Валидация, что юзер существует
        if (_userRepository.GetUserByEmail(query.Email) is not User user)
        {
            return Errors.Authentication.InvalidCredentials;
        }
            
        //2. Валидация, что пароль корректный
        if (user.Password != query.Password)
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