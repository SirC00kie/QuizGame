using System.Reflection;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using QuizGame.Application.Authentication.Commands.Register;
using QuizGame.Application.Authentication.Common;
using QuizGame.Application.Common.Behaviors;

namespace QuizGame.Application
{
    public static class DependencyInjections
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(DependencyInjections).Assembly);
            
            services.AddScoped(typeof(IPipelineBehavior<,>),
                typeof(ValidationBehavior<,>)); 
            
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            
            return services;
        }
    }
}