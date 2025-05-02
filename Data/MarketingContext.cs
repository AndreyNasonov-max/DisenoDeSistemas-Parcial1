// Data/MarketingContext.cs
using Microsoft.EntityFrameworkCore;
using SistemaMarketing.Models;

namespace SistemaMarketing.Data
{
    public class MarketingContext : DbContext
    {
        public MarketingContext(DbContextOptions<MarketingContext> options) 
            : base(options) { }

        public DbSet<Cliente> Clientes { get; set; }
        // Only DB-related configurations here
    }
}