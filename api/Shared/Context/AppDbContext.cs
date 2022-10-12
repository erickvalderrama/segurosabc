using api.Clientes.Domain.DTO;
using api.Clientes.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace api.Shared.Context
{
    public class AppDbContext : DbContext
    {

        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<ClientPayment> ClientPayment { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>().ToTable("clients");
            modelBuilder.Entity<Payment>().ToTable("payments");
        }
    }
}
