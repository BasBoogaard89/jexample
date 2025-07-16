namespace Domain.Entities;

public class Company : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public Address Address { get; set; } = null!;

    public List<Vacancy> Vacancies { get; set; } = [];
}
