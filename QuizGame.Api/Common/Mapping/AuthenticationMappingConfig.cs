using Mapster;
using QuizGame.Application.Authentication.Commands.Register;
using QuizGame.Application.Authentication.Common;
using QuizGame.Application.Authentication.Queries.Login;
using QuizGame.Contracts.Authentication;

namespace QuizGame.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();
        config.NewConfig<LoginRequest, LoginQuery>();
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
            .Map(dest => dest, src => src.User);
    }
}