using Domain.Entities;

namespace Infrastructure.Context;

public static class ExampleDataSeeder
{
    public static void Seed(AppDbContext context)
    {
        
        if (!context.Companies.Any())
        {
            context.Companies.AddRange(new Company
            {
                Name = "JEXample",
                Address = new Address { Street = "Baanlaan", Number = "010", ZipCode = "1908FR", City = "010" },
            },
            new Company
            {
                Name = "DSB Bank",
                Address = new Address { Street = "Bankje bij het station", Number = "7", ZipCode = "0000", City = "Faillieterdam" },
            });
        }

        if (!context.Vacancies.Any())
        {
            context.Vacancies.AddRange(new Vacancy
            {
                Title = "Vacature Backend",
                CompanyId = 1
            });
        }

        context.SaveChanges();
    }
}
