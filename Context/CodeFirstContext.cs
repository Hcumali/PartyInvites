using Microsoft.EntityFrameworkCore;
using PartyInvites.Models;

namespace PartyInvites.Context
{
    public class CodeFirstContext : DbContext
    {
        public CodeFirstContext(DbContextOptions<CodeFirstContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserDetail> UserDetails { get; set; }
        public DbSet<Party> Parties { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}

