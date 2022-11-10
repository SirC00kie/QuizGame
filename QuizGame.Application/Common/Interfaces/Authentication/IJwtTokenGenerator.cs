using System;
using QuizGame.Domain.Entities;

namespace QuizGame.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}