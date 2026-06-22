using DAL.Data;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class CustomerRepository : IRepository<Customer>
{
    private readonly AppDbContext ctx;

    public CustomerRepository(AppDbContext ctx) => this.ctx = ctx;

   	public async Task<List<Customer>> GetAllAsync() => 
    await ctx.Customers.Include(c => c.Rentals).ToListAsync();

	public async Task<Customer?> GetByIdAsync(int id) => 
    await ctx.Customers.Include(c => c.Rentals).FirstOrDefaultAsync(c => c.Id == id);

	public async Task<bool> AddAsync(Customer customer) {
        ctx.Customers.Add(customer); 
        return await ctx.SaveChangesAsync() > 0; 
    }

    public async Task<bool> UpdateAsync(Customer customer)
    {
        ctx.Customers.Update(customer);
        return await ctx.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var c = await ctx.Customers.FindAsync(id);
        if (c == null) return false;
        ctx.Customers.Remove(c);
        return await ctx.SaveChangesAsync() > 0;
    }
}
