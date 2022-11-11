using Microsoft.Extensions.DependencyInjection;
using QuizGame.Application.Services.Authentication;
using QuizGame.Application.Services.Authentication.Commands;
using QuizGame.Application.Services.Authentication.Queries;

namespace QuizGame.Application
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationCommandService, AuthenticationCommandService>();
            services.AddScoped<IAuthenticationQueryService, AuthenticationQueryService>();
            return services;
        }
    }
}