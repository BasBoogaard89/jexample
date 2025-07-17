using System.ComponentModel.DataAnnotations;

namespace Application.Dtos;

public class VacancyDto : BaseDto
{
    [Required]
    public string Title { get; set; } = string.Empty;

    [Required]
    public string? Content { get; set; }

    [Required]
    public int CompanyId { get; set; }

    public CompanyDto? Company { get; set; }
}
