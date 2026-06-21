using DAL.Data;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class VehicleRepository : IRepository<Vehicle>
{
    private readonly AppDbContext ctx;

    public VehicleRepository(AppDbContext ctx) => this.ctx = ctx;

    public List<Vehicle> GetAll() =>
        ctx.Vehicles.Include(v => v.Rentals).ToList();

    public Vehicle GetById(int id) =>
        ctx.Vehicles.Include(v => v.Rentals)
            .FirstOrDefault(v => v.Id == id);

    public bool Add(Vehicle vehicle)
    {
        ctx.Vehicles.Add(vehicle);
        return ctx.SaveChanges() > 0;
    }

    public bool Update(Vehicle vehicle)
    {
        ctx.Vehicles.Update(vehicle);
        return ctx.SaveChanges() > 0;
    }

    public bool Delete(int id)
    {
        var v = ctx.Vehicles.Find(id);
        if (v == null) return false;
        ctx.Vehicles.Remove(v);
        return ctx.SaveChanges() > 0;
    }
}