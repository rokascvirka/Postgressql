using Microsoft.EntityFrameworkCore;
using Postgressql.DbContexts;
using Postgressql.Interfaces;
using Postgressql.Models;

namespace Postgressql.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        private readonly ApplicationDbContext _context;
        public SessionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Session session) 
        {
            _context.Sessions.Add(session);
            await _context.SaveChangesAsync();
        }
        public async Task<Session> GetByIdAsync(int id)
        {
            return await _context.Sessions.FindAsync(id) ?? throw new ArgumentException("Not Found");
        }
        public async Task DeleteByIdAsync(int id)
        {
            var session = await GetByIdAsync(id);
            if (session != null)
            {
                _context.Sessions.Remove(session);
                await _context.SaveChangesAsync();
            }
        }


        public async Task<Session> GetByTokenAsync(string token)
        {
            return await _context.Sessions.FirstOrDefaultAsync(x => x.Token == token) ?? throw new ArgumentException("Not Found"); ;   
        }

        public async Task UpdateByIdAsync(int id, string returnUrl)
        {
            var session = await GetByIdAsync(id);
            if (session == null) 
            {
                throw new ArgumentException("Not found");
            }

            session.ReturnUrl = returnUrl;
            await _context.SaveChangesAsync();
        }
    }
}
