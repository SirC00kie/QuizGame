using Microsoft.AspNetCore.Mvc.Infrastructure;
using QuizGame.Api.Common.Errors;
using QuizGame.Api.Common.Mapping;

namespace QuizGame.Api
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();
            services.AddSingleton<ProblemDetailsFactory, QuizGameProblemDetailsFactory>();
            services.AddMapping();
            return services;
        }
    }
}