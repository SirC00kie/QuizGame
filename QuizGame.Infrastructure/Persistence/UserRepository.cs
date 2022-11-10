using QuizGame.Application.Common.Interfaces.Persistence;
using QuizGame.Domain.Entities;

namespace QuizGame.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = new();
    public User? GetUserByEmail(string email)
    {
        return _users.SingleOrDefault(user => user.Email == email);
    }

    public void Add(User user)
    {
        _users.Add(user);
    }
}