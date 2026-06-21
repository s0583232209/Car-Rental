using DAL.Data;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class RentalRepository : IRepository<Rental>
{
    private readonly AppDbContext ctx;

    public RentalRepository(AppDbContext ctx) => ctx = ctx;

    public List<Rental> GetAll() =>
        ctx.Rentals
            .Include(r => r.Customer)
            .Include(r => r.Car)
            .ToList();

    public Rental GetById(int id) =>
        ctx.Rentals
            .Include(r => r.Customer)
            .Include(r => r.Car)
            .FirstOrDefault(r => r.Id == id);

    public bool Add(Rental rental)
    {
        ctx.Rentals.Add(rental);
        return ctx.SaveChanges() > 0;
    }

    public bool Update(Rental rental)
    {
        ctx.Rentals.Update(rental);
        return ctx.SaveChanges() > 0;
    }

    public bool Delete(int id)
    {
        var r = ctx.Rentals.Find(id);
        if (r == null) return false;
        ctx.Rentals.Remove(r);
        return ctx.SaveChanges() > 0;
    }
}