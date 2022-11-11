using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using QuizGame.Application.Authentication.Commands.Register;
using QuizGame.Application.Authentication.Common;
using QuizGame.Application.Authentication.Queries.Login;
using QuizGame.Contracts.Authentication;
using QuizGame.Domain.Common.Errors;

namespace QuizGame.Api.Controllers;

[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly ISender _mediator;

    public AuthenticationController(ISender mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = new RegisterCommand(request.Name, request.Email, request.Password);
        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);
        
        return authResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = new LoginQuery(request.Email, request.Password);
        var authResult = await _mediator.Send(query);

        if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
        {
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized,
                title: authResult.FirstError.Description);
        }

        return authResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors));
    }

    private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
    {
        var response = new AuthenticationResponse(
            authResult.User.Id,
            authResult.User.Name,
            authResult.User.Email,
            authResult.Token);
        return response;
    }
}