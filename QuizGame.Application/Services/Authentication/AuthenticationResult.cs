﻿using System;

namespace QuizGame.Application.Services.Authentication
{
    public record AuthenticationResult(
        Guid Id,
        string Name,
        string Email,
        string Token);
}