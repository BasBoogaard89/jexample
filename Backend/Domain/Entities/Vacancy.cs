namespace Domain.Entities;

public class Vacancy : BaseEntity
{
    public string Title { get; set; }
    public int CompanyId { get; set; }

}
