using System.ComponentModel.DataAnnotations;

namespace Application.Dtos;

public class AddressDto : BaseDto
{
    [Required]
    public string Street { get; set; } = string.Empty;

    [Required]
    public string Number { get; set; } = string.Empty;

    [Required]
    public string ZipCode { get; set; } = string.Empty;

    [Required]
    public string City { get; set; } = string.Empty;
}
