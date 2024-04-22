using CoWorkingSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CoWorkingSystem.Data
{
    public class BankContext : DbContext
    {
        public BankContext(DbContextOptions<BankContext> options) : base(options)
        {
        }
        public DbSet<ClientModel> Clients { get; set; }
    }
}
