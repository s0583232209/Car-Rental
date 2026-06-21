using Services.DTOs;
using Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentsController : ControllerBase
{
    private readonly IService<PaymentDTO> _service;

    public PaymentsController(IService<PaymentDTO> service) => _service = service;

    [HttpGet]
    public IActionResult GetAll() => Ok(_service.GetAll());

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var p = _service.GetById(id);
        return p == null ? NotFound() : Ok(p);
    }

    [HttpPost]
    public IActionResult Create(PaymentDTO dto)
    {
        bool ok = _service.Add(dto);
        return ok ? Ok(dto) : BadRequest();
    }
}