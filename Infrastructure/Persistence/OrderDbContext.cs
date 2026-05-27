using Microsoft.EntityFrameworkCore;
using Ticketinho.Infrastructure.Entities;

namespace Ticketinho.Infrastructure.Persistence
{
    public class OrderDbContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Event> Events { get; set; }

        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                .HasKey(o => o.Id);

            modelBuilder.Entity<Ticket>()
                .HasKey(t => t.Id);

            modelBuilder.Entity<Event>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Event)
                .WithMany(e => e.Orders)
                .HasForeignKey(o => o.EventId);

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.Order)
                .WithMany(o => o.Tickets)
                .HasForeignKey(t => t.OrderId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
