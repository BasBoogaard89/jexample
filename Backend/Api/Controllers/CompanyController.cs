using Application.Dtos;
using Application.Interfaces.Services;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Api.Controllers;

public class CompanyController(IMapper mapper, ICompanyService companyService) : BaseController(mapper)
{
    [HttpGet]
    [ProducesResponseType(typeof(List<CompanyDto>), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetAll()
    {
        var data = await companyService.GetAll();
        var dto = mapper.Map<List<CompanyDto>>(data);

        return Ok(data);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(CompanyDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> GetById(int id)
    {
        var data = await companyService.GetById(id);
        var dto = mapper.Map<CompanyDto>(data);

        return Ok(dto);
    }

    [HttpPost]
    [ProducesResponseType(typeof(CompanyDto), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Save([FromBody] CompanyDto dto)
    {
        var entity = mapper.Map<Company>(dto);
        var data = await companyService.Save(entity);
        var updatedDto = mapper.Map<CompanyDto>(data);

        return Ok(updatedDto);
    }

    [HttpDelete]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await companyService.Delete(id);

        return Ok(result);
    }
}
