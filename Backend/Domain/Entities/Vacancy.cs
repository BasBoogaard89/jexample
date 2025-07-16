namespace Domain.Entities;

public class Vacancy : BaseEntity
{
    public string Title { get; set; } = string.Empty;
    public string? Content { get; set; }
    public int CompanyId { get; set; }
    public Company Company { get; set; } = null!;

}
