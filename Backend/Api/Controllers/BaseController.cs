using Application.Interfaces.Services;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Net;

[ApiController]
[Route("[controller]")]
public abstract class BaseController<TEntity, TDto, TService>(IMapper mapper,TService service) : ControllerBase
    where TEntity : BaseEntity
    where TDto : class
    where TService : IBaseService<TEntity>
{
    [HttpGet]
    public virtual async Task<IActionResult> GetAll()
    {
        var data = await service.GetAll();
        var dto = mapper.Map<List<TDto>>(data);
        return Ok(dto);
    }

    [HttpGet("{id}")]
    public virtual async Task<IActionResult> GetById(int id)
    {
        var data = await service.GetById(id);
        var dto = mapper.Map<TDto>(data);
        return Ok(dto);
    }

    [HttpPost]
    public virtual async Task<IActionResult> Save([FromBody] TDto dto)
    {
        var entity = mapper.Map<TEntity>(dto);
        var data = await service.Save(entity);
        var updatedDto = mapper.Map<TDto>(data);
        return Ok(updatedDto);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(bool), (int)HttpStatusCode.OK)]
    public virtual async Task<IActionResult> Delete(int id)
    {
        var result = await service.Delete(id);
        return Ok(result);
    }
}
