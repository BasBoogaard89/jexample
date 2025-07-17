using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Company> Companies { get; set; }
    public DbSet<Vacancy> Vacancies { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Company>()
            .OwnsOne(c => c.Address);

        modelBuilder.Entity<Company>()
            .Navigation(c => c.Vacancies)
            .AutoInclude();

        modelBuilder.Entity<Vacancy>()
            .Navigation(c => c.Company)
            .AutoInclude();
    }

}
