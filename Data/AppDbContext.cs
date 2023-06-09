using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Reserve> Reserves { get; set; }
    public DbSet<Book> Books { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Reserve>()
            .HasKey(r => r.Id);

        modelBuilder.Entity<Reserve>()
            .HasOne(r => r.User)
            .WithMany(u => u.Reserves)
            .HasForeignKey(r => r.User_Id);

        modelBuilder.Entity<Reserve>()
            .HasOne(r => r.Book)
            .WithMany(b => b.Reserves)
            .HasForeignKey(r => r.Book_Id);

        base.OnModelCreating(modelBuilder);
    }
}
