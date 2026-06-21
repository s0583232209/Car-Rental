using Infrastructure.DTOs;
using Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RentalsController : ControllerBase
{
    private readonly IService<RentalDTO> _service;

    public RentalsController(IService<RentalDTO> service) => _service = service;

    [HttpGet]
    public IActionResult GetAll() => Ok(_service.GetAll());

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var r = _service.GetById(id);
        return r == null ? NotFound() : Ok(r);
    }

    // POST – פתיחת השכרה חדשה
    [HttpPost]
    public IActionResult Create(RentalDTO dto)
    {
        bool ok = _service.Add(dto);
        return ok ? Ok(dto) : BadRequest();
    }

    // PUT – סגירת השכרה (חישוב מחיר בתוך השירות)
    [HttpPut("{id}")]
    public IActionResult CloseRental(int id)
    {
        var rental = _service.GetById(id);
        if (rental == null) return NotFound();
        bool ok = _service.Update(rental);
        return ok ? Ok(rental) : BadRequest();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id) =>
        _service.Delete(id) ? NoContent() : NotFound();
}