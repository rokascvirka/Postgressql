using Postgressql.Models;

namespace Postgressql.Interfaces
{
    public interface ISessionRepository
    {
        Task AddAsync(Session session);
        Task<Session> GetByIdAsync(int id);
        Task UpdateByIdAsync(int id, string returnUrl);
        Task DeleteByIdAsync(int id);
        Task<Session> GetByTokenAsync(string token);
    }
}
