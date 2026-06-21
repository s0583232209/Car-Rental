using DAL.Data;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class CustomerRepository : IRepository<Customer>
{
    private readonly AppDbContext ctx;

    public CustomerRepository(AppDbContext ctx) => this.ctx = ctx;

    public List<Customer> GetAll() =>
        ctx.Customers.Include(c => c.Rentals).ToList();

    public Customer GetById(int id) =>
        ctx.Customers.Include(c => c.Rentals)
            .FirstOrDefault(c => c.Id == id);

    public bool Add(Customer customer)
    {
        ctx.Customers.Add(customer);
        return ctx.SaveChanges() > 0;
    }

    public bool Update(Customer customer)
    {
        ctx.Customers.Update(customer);
        return ctx.SaveChanges() > 0;
    }

    public bool Delete(int id)
    {
        var c = ctx.Customers.Find(id);
        if (c == null) return false;
        ctx.Customers.Remove(c);
        return ctx.SaveChanges() > 0;
    }
}
