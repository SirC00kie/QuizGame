using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace QuizGame.Application
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(DependencyInjections).Assembly);
            return services;
        }
    }
}