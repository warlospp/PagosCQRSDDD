using Microsoft.EntityFrameworkCore;
using PagosCQRSDDD.Domain.Entities;

namespace PagosCQRSDDD.Infrastructure.Persistence
{
    public class PagosDbContexts : DbContext
    {
        public PagosDbContext(DbContextOptions<PagosDbContext> options) : base(options) { }

        public DbSet<Pago> Pagos { get; set; }
    }
}