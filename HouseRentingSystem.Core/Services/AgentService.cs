using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Core.Services
{
    public class AgentService : IAgentService
    {
        private readonly HouseRentingDbContext _context;

        public AgentService(HouseRentingDbContext context)
        {
            _context = context;
        }
        public async Task<bool> ExistsById(string userId)
        {
            return await _context.Agents
                .AnyAsync(a => a.UserId == userId);
        }

        public async Task<bool> UserWithPhoneNumberExists(string phoneNumber)
        {
            return await _context.Agents
                .AnyAsync(a => a.PhoneNumber == phoneNumber);
        }

        public async Task<bool> UserHasRents(string userId)
        {
            return await _context.Houses
                .AnyAsync(h => h.RenterId == userId);
        }

        public async Task Create(string userId, string phoneNumber)
        {
            var agent = new Agent()
            {
                UserId = userId,
                PhoneNumber = phoneNumber
            };

            await _context.Agents.AddAsync(agent);
            await _context.SaveChangesAsync();
        }
    }
}
