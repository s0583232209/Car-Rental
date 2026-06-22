using DAL.Data;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class RentalRepository : IRepository<Rental>
{
    private readonly AppDbContext ctx;

    public RentalRepository(AppDbContext ctx) => this.ctx = ctx;

    public async Task<List<Rental>> GetAllAsync() =>
        await ctx.Rentals
            .Include(r => r.Customer)
            .Include(r => r.Car)
            .ToListAsync();

    public async Task<Rental?> GetByIdAsync(int id) =>
        await ctx.Rentals
            .Include(r => r.Customer)
            .Include(r => r.Car)
            .FirstOrDefaultAsync(r => r.Id == id);

    public async Task<bool> AddAsync(Rental rental)
    {
        ctx.Rentals.Add(rental);
        return await ctx.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateAsync(Rental rental)
    {
        ctx.Rentals.Update(rental);
        return await ctx.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var r = await ctx.Rentals.FindAsync(id);
        if (r == null) return false;
        ctx.Rentals.Remove(r);
        return await ctx.SaveChangesAsync() > 0;
    }
}