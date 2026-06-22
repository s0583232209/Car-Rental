using DAL.Data;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class PaymentRepository : IRepository<Payment>
{
    private readonly AppDbContext ctx;

    public PaymentRepository(AppDbContext ctx) => ctx = ctx;

    public async Task<List<Payment>> GetAllAsync() =>
        await ctx.Payments.Include(p => p.Rental).ToListAsync();

    public async Task<Payment?> GetByIdAsync(int id) =>
        await ctx.Payments.FindAsync(id);

    public async Task<bool> AddAsync(Payment payment)
    {
        ctx.Payments.Add(payment);
        return await ctx.SaveChangesAsync() > 0;
    }

    public async Task<bool> UpdateAsync(Payment payment)
    {
        ctx.Payments.Update(payment);
        return await ctx.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var p = await ctx.Payments.FindAsync(id);
        if (p == null) return false;
        ctx.Payments.Remove(p);
        return await ctx.SaveChangesAsync() > 0;
    }
}