using Infrastructure.DTOs;
using Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehiclesController : ControllerBase
{
    private readonly IService<VehicleDTO> _service;

    public VehiclesController(IService<VehicleDTO> service) => _service = service;

    [HttpGet]
    public IActionResult GetAll() => Ok(_service.GetAll());

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var v = _service.GetById(id);
        return v == null ? NotFound() : Ok(v);
    }

    [HttpPost]
    public IActionResult Create(VehicleDTO dto)
    {
        bool ok = _service.Add(dto);
        return ok ? Ok(dto) : BadRequest();
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, VehicleDTO dto)
    {
        if (id != dto.Id) return BadRequest();
        return _service.Update(dto) ? NoContent() : NotFound();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id) =>
        _service.Delete(id) ? NoContent() : NotFound();
}