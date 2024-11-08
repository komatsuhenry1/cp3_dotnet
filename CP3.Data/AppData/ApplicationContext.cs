using Microsoft.EntityFrameworkCore;
using CP3.Domain.Entities;

namespace CP3.Data.AppData
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<BarcoEntity> Barco { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BarcoEntity>(entity =>
            {
                entity.ToTable("Barco");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nome).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Modelo).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Ano).IsRequired();
                entity.Property(e => e.Tamanho).IsRequired();
            });
        }
    }
}
