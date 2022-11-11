using Microsoft.AspNetCore.Mvc.Infrastructure;
using QuizGame.Api.Common.Errors;
using QuizGame.Application;
using QuizGame.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration); 
    
    builder.Services.AddControllers();

    builder.Services.AddSingleton<ProblemDetailsFactory, QuizGameProblemDetailsFactory>();
}

var app = builder.Build();
{
    app.UseExceptionHandler("/error");
    
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}
