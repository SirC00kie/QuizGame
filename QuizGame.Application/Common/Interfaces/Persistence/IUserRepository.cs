using QuizGame.Domain.Entities;

namespace QuizGame.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void Add(User user);
}