using Microsoft.Extensions.DependencyInjection;
using QuizGame.Application.Services.Authentication;

namespace QuizGame.Application
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            return services;
        }
    }
}