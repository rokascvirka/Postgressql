using Postgressql.Interfaces;
using Postgressql.Models;

namespace Postgressql.Services
{
    public class SessionService : ISessionService
    {
        private readonly ISessionRepository _sessionRepository;
        public SessionService(ISessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }
        public async Task AddSessionAsync(Session session)
        {
            await _sessionRepository.AddAsync(session);
        }
        public async Task DeleteSessionByIdAsync(int id)
        {
             await _sessionRepository.DeleteByIdAsync(id);
        }

        public Task<Session> GetBySessionTokenAsync(string token)
        {
            return _sessionRepository.GetByTokenAsync(token);
        }

        public Task<Session> GetSessionByIdAsync(int id)
        {
            return _sessionRepository.GetByIdAsync(id);
        }

        public async Task UpdateSessionByIdAsync(int id, string returnUrl)
        {
            await _sessionRepository.UpdateByIdAsync(id, returnUrl);
        }
    }
}
