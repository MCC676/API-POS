using Microsoft.EntityFrameworkCore;
using POS.Domain.Entities;
using POS.Infraestructure.Persistences.Contexts;
using POS.Infraestructure.Persistences.Interfaces;

namespace POS.Infraestructure.Persistences.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly PosContext _context;
        public UserRepository(PosContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> UserByEmail(string email)
        {
            var user = await _context.Users.AsNoTracking()
                    .FirstOrDefaultAsync(x => x.Email!.Equals(email));
            return user!;
        }
    }
}
