using System.ComponentModel.DataAnnotations;

namespace Application.Dtos;

public class CompanyDto : BaseDto
{
    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public AddressDto Address { get; set; } = null!;

    public List<VacancyDto> Vacancies { get; set; } = [];
}
