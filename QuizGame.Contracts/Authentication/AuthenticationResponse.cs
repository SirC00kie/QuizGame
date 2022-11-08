using System;

namespace QuizGame.Contracts.Authentication
{
    public record AuthenticationResponse(
        Guid Id,
        string Name,
        string Email,
        string Token);
}