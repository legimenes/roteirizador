using Microsoft.EntityFrameworkCore;
using Roteirizador.Domain.Models;

namespace Roteirizador.Data.Context
{
    public class RouterDbContext : DbContext
    {
        public RouterDbContext(DbContextOptions<RouterDbContext> options) : base(options) { }

        public DbSet<UF> UFs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLowerCaseNamingConvention();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(RouterDbContext).Assembly);
        }
    }
}