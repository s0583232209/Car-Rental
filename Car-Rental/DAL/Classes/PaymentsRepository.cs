using DAL.Data;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class PaymentRepository : IRepository<Payment>
{
    private readonly AppDbContext _ctx;

    public PaymentRepository(AppDbContext ctx) => _ctx = ctx;

    public List<Payment> GetAll() =>
        _ctx.Payments.Include(p => p.Rental).ToList();

    public Payment GetById(int id) =>
        _ctx.Payments.Find(id);

    public bool Add(Payment payment)
    {
        _ctx.Payments.Add(payment);
        return _ctx.SaveChanges() > 0;
    }

    public bool Update(Payment payment)
    {
        _ctx.Payments.Update(payment);
        return _ctx.SaveChanges() > 0;
    }

    public bool Delete(int id)
    {
        var p = _ctx.Payments.Find(id);
        if (p == null) return false;
        _ctx.Payments.Remove(p);
        return _ctx.SaveChanges() > 0;
    }
}