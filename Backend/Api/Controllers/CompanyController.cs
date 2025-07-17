using Application.Dtos;
using Application.Dtos.Filters;
using Application.Interfaces.Services;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Controllers;

public class CompanyController(IMapper mapper, ICompanyService companyService) : BaseController<Company, CompanyDto, ICompanyService>(mapper, companyService)
{

    [HttpPost("GetAllFiltered")]
    [ProducesResponseType(typeof(List<CompanyDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAllFiltered([FromBody] CompanyFilterDto filters)
    {
        var data = await companyService.GetAllFiltered(filters);
        var dto = mapper.Map<List<CompanyDto>>(data);

        return Ok(data);
    }
}
