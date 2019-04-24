namespace Domain
{
    using Domain.Entity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class DBContext : IdentityDbContext
    {

        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        public DbSet<RateDomain> Rates { get; set; }
        public DbSet<TransactionDomain> Transactions { get; set; }
    }
}