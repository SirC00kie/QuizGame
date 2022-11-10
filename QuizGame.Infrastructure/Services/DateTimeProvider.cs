using System;
using QuizGame.Application.Common.Interfaces.Services;

namespace QuizGame.Infrastructure.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}