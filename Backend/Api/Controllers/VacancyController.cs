using Application.Dtos;
using Application.Dtos.Filters;
using Application.Interfaces.Services;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

public class VacancyController(IMapper mapper, IVacancyService vacancyService) : BaseController<Vacancy, VacancyDto, IVacancyService>(mapper, vacancyService)
{
    [HttpPost("GetAllFiltered")]
    [ProducesResponseType(typeof(List<VacancyDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAllFiltered([FromBody] VacancyFilterDto filters)
    {
        var data = await vacancyService.GetAllFiltered(filters);
        var dto = mapper.Map<List<VacancyDto>>(data);

        return Ok(data);
    }
}
