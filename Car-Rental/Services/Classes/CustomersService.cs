using DAL.Interfaces;
using DAL.Entities;
using Services.DTOs;
using Services.Interfaces;
using AutoMapper;

namespace Services.Classes;

public class CustomerService : IService<CustomerDTO>
{
    private readonly IRepository<Customer> _repo;
    private readonly IMapper<Customer> mapper;
    public CustomerService(IRepository<Customer> repo) => _repo = repo;

    public List<CustomerDTO> GetAll()
    {
        var customers = _repo.GetAll();
        return customers.Select(c => new CustomerDTO
        {
            Id = c.Id,
            FullName = c.FullName,
            Email = c.Email,
            Phone = c.Phone
        }).ToList();
    }

    public CustomerDTO GetById(int id)
    {
        var c = _repo.GetById(id);
        if (c == null) return null;
        return new CustomerDTO
        {
            Id = c.Id,
            FullName = c.FullName,
            Email = c.Email,
            Phone = c.Phone
        };
    }

    public bool Add(CustomerDTO dto)
    {
        if (string.IsNullOrWhiteSpace(dto.FullName)) return false;
        var customer = new Customer
        {
            FullName = dto.FullName,
            Email = dto.Email,
            Phone = dto.Phone
        };
        return _repo.Add(customer);
    }

    public bool Update(CustomerDTO dto)
    {
        var customer = new Customer
        {
            Id = dto.Id,
            FullName = dto.FullName,
            Email = dto.Email,
            Phone = dto.Phone
        };
        return _repo.Update(customer);
    }

    public bool Delete(int id) => _repo.Delete(id);

    CustomerDTO IService<CustomerDTO>.Add(CustomerDTO entity)
    {
        throw new NotImplementedException();
    }
}