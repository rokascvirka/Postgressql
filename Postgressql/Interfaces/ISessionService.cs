using Postgressql.Models;

namespace Postgressql.Interfaces
{
    public interface ISessionService
    {
        Task AddSessionAsync(Session session);
        Task<Session> GetSessionByIdAsync(int id);
        Task UpdateSessionByIdAsync(int id, string returnUrl);
        Task DeleteSessionByIdAsync(int id);
        Task<Session> GetBySessionTokenAsync(string token);
    }
}
