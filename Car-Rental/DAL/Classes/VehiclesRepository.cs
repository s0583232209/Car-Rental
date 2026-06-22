using DAL.Data;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class VehicleRepository : IRepository<Vehicle>
{
    private readonly AppDbContext ctx;

    public VehicleRepository(AppDbContext ctx) => this.ctx = ctx;

    public async Task<List<Vehicle>> GetAllAsync() =>
        await ctx.Vehicles.Include(v => v.Rentals).ToListAsync();

    public async Task<Vehicle?> GetByIdAsync(int id) =>
        await ctx.Vehicles.Include(v => v.Rentals)
            .FirstOrDefaultAsync(v => v.Id == id);

    public async Task<bool> AddAsync(Vehicle vehicle)
    {
        ctx.Vehicles.Add(vehicle);
        return await ctx.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateAsync(Vehicle vehicle)
    {
        ctx.Vehicles.Update(vehicle);
        return await ctx.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var v = await ctx.Vehicles.FindAsync(id);
        if (v == null) return false;
        ctx.Vehicles.Remove(v);
        return await ctx.SaveChangesAsync() > 0;
    }
}