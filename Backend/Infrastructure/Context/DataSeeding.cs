using Domain.Entities;

namespace Infrastructure.Context;

public static class ExampleDataSeeder
{
    public static void Seed(AppDbContext context)
    {
        if (!context.Companies.Any())
        {
            context.Companies.Add(new Company { Name = "JEXample Inc." });
        }

        if (!context.Vacancies.Any())
        {
            context.Vacancies.Add(new Vacancy { Title = "Vacature Specialist", CompanyId = 1 });
        }

        context.SaveChanges();
    }
}
