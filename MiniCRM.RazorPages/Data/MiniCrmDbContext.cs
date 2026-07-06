using Microsoft.EntityFrameworkCore;
using MiniCRM.RazorPages.Models;

namespace MiniCRM.RazorPages.Data;

public class MiniCrmDbContext : DbContext
{
    public MiniCrmDbContext(DbContextOptions<MiniCrmDbContext> options)
        : base(options)
    {
    }

    public DbSet<ApplicationUser> Users => Set<ApplicationUser>();
    public DbSet<Customer> Customers => Set<Customer>();
    public DbSet<Attendance> Attendances => Set<Attendance>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ApplicationUser>()
            .HasIndex(user => user.Email)
            .IsUnique();

        modelBuilder.Entity<Customer>()
            .HasIndex(customer => customer.Email);

        modelBuilder.Entity<Customer>()
            .Property(customer => customer.DataCadastro)
            .HasDefaultValueSql("GETDATE()");

        modelBuilder.Entity<Attendance>()
            .Property(attendance => attendance.DataAtendimento)
            .HasDefaultValueSql("GETDATE()");

        modelBuilder.Entity<Attendance>()
            .HasOne(attendance => attendance.Cliente)
            .WithMany(customer => customer.Atendimentos)
            .HasForeignKey(attendance => attendance.ClienteId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
