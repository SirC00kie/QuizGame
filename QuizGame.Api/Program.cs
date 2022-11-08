using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using QuizGame.Application;
using QuizGame.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplication()
        .AddInfrastructure(); 
    
    builder.Services.AddControllers();
}

var app = builder.Build();
{
    app.UseHttpsRedirection();
    app.MapControllers();

    app.Run();
}
