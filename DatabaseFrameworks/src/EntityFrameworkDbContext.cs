using Microsoft.EntityFrameworkCore;

namespace DatabaseFrameworks;

public class EntityFrameworkDbContext() : DbContext
{
    public DbSet<Person> Person { get; set; }
    public DbSet<Account> Account { get; set; }
    public DbSet<Address> Address { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=127.0.0.1,1433;Database=benchmarks;User Id=sa;Password=SqlServer2022!;TrustServerCertificate=true;");
    }
}
