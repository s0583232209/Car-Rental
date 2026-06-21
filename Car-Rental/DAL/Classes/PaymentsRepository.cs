using DAL.Data;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class PaymentRepository : IRepository<Payment>
{
    private readonly AppDbContext ctx;

    public PaymentRepository(AppDbContext ctx) => ctx = ctx;

    public List<Payment> GetAll() =>
        ctx.Payments.Include(p => p.Rental).ToList();

    public Payment GetById(int id) =>
        ctx.Payments.Find(id);

    public bool Add(Payment payment)
    {
        ctx.Payments.Add(payment);
        return ctx.SaveChanges() > 0;
    }

    public bool Update(Payment payment)
    {
        ctx.Payments.Update(payment);
        return ctx.SaveChanges() > 0;
    }

    public bool Delete(int id)
    {
        var p = ctx.Payments.Find(id);
        if (p == null) return false;
        ctx.Payments.Remove(p);
        return ctx.SaveChanges() > 0;
    }
}