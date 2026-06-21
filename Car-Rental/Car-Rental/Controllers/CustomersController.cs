using Services.DTOs;
using Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomersController : ControllerBase
{
    private readonly IService<CustomerDTO> _service;

    public CustomersController(IService<CustomerDTO> service)
    {
        _service = service;
    }

    // GET api/customers
    [HttpGet]
    public IActionResult GetAll()
    {
        //return Ok("get all");
        var customers = _service.GetAll();
        return Ok(customers);
    }

    // GET api/customers/5
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var customer = _service.GetById(id);
        if (customer == null) return NotFound();
        return Ok(customer);
    }

    // POST api/customers
    [HttpPost]
    public IActionResult Create(CustomerDTO dto)
    {
        bool ok = _service.Add(dto);
        if (!ok) return BadRequest();
        return Ok(dto);
    }

    // PUT api/customers/5
    [HttpPut("{id}")]
    public IActionResult Update(int id, CustomerDTO dto)
    {
        if (id != dto.Id) return BadRequest();
        bool ok = _service.Update(dto);
        return ok ? NoContent() : NotFound();
    }

    // DELETE api/customers/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        bool ok = _service.Delete(id);
        return ok ? NoContent() : NotFound();
    }
}