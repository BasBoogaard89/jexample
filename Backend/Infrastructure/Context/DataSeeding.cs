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
                Address = new Address { Street = "Baanlaan", Number = "010", ZipCode = "1908FR", City = "Ken je niet horen ofzo?" },
            },
            new Company
            {
                Name = "DSB Bank",
                Address = new Address { Street = "Bankje bij het station", Number = "7", ZipCode = "0000", City = "Faillieterdam" },
            },
            new Company
            {
                Name = "TWS Tussen wal & schip",
                Address = new Address { Street = "Testlaan", Number = "-99", ZipCode = "ABCD01", City = "Testerdam" },
            });
        }

        if (!context.Vacancies.Any())
        {
            context.Vacancies.AddRange(new Vacancy
            {
                Title = "Backend developer",
                Content = "Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi architecto beatae vitae dicta sunt explicabo.",
                CompanyId = 1
            },
            new Vacancy
            {
                Title = "Administratief medewerker",
                Content = "Et harum quidem rerum facilis est et expedita distinctio. Nam libero tempore, cum soluta nobis est eligendi optio cumque nihil impedit quo minus id quod maxime placeat facere possimus, omnis voluptas assumenda est, omnis dolor repellendus. Temporibus autem quibusdam et aut officiis debitis aut rerum necessitatibus saepe eveniet ut et voluptates repudiandae sint et molestiae non recusandae.",
                CompanyId = 3
            },
            new Vacancy
            {
                Title = "Receptionist(e)",
                Content = "Aliquam at tellus ac massa euismod interdum. Nam pharetra tempor nunc nec rutrum. Nulla facilisi. Nunc feugiat scelerisque faucibus. Curabitur fringilla neque non turpis sodales, eget egestas nunc scelerisque. Maecenas et pharetra mi. Vestibulum suscipit lectus eget erat aliquet, quis convallis velit consectetur.",
                CompanyId = 3
            },
            new Vacancy
            {
                Title = "Heftruckchauffeur",
                Content = "Proin efficitur urna vel arcu hendrerit volutpat. Sed interdum eget nisi sit amet euismod. Sed accumsan tristique massa a suscipit. Maecenas tincidunt, lorem tincidunt aliquam mattis, justo felis elementum magna, ut auctor justo dui sit amet diam.",
                CompanyId = 3
            });
        }

        context.SaveChanges();
    }
}
