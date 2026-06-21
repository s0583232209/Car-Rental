using DAL.Data;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class VehicleRepository : IVehicleRepository
{
    private readonly AppDbContext _ctx;
    public VehicleRepository(AppDbContext ctx) => _ctx = ctx;

    public async Task<IEnumerable<Vehicle>> GetAllAsync() =>
        await _ctx.Vehicles.ToListAsync();

    public async Task<Vehicle?> GetByIdAsync(int id) =>
        await _ctx.Vehicles.FindAsync(id);

    // רכב זמין = אין לו השכרה שעדיין פתוחה (EndDate == null)
    public async Task<IEnumerable<Vehicle>> GetAvailableAsync() =>
        await _ctx.Vehicles
            .Where(v => !v.Rentals.Any(r => r.EndDate == null))
            .ToListAsync();

    public async Task AddAsync(Vehicle v) { _ctx.Vehicles.Add(v); await _ctx.SaveChangesAsync(); }
    public async Task UpdateAsync(Vehicle v) { _ctx.Vehicles.Update(v); await _ctx.SaveChangesAsync(); }
    public async Task DeleteAsync(int id)
    {
        var v = await _ctx.Vehicles.FindAsync(id);
        if (v != null) { _ctx.Vehicles.Remove(v); await _ctx.SaveChangesAsync(); }
    }
}
