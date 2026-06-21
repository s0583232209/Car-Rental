using DAL.Interfaces;
using DAL.Entities;
using Services.DTOs;
using Services.Interfaces;

namespace Services.Classes;

public class PaymentService : IService<PaymentDTO>
{
    private readonly IRepository<Payment> _repo;

    public PaymentService(IRepository<Payment> repo) => _repo = repo;

    public List<PaymentDTO> GetAll()
    {
        return _repo.GetAll().Select(p => new PaymentDTO
        {
            Id = p.Id,
            RentalId = new Rental(p.RentalId),
            Amount = p.Amount,
            PaymentDate = p.PaymentDate
        }).ToList();
    }

    public PaymentDTO GetById(int id)
    {
        var p = _repo.GetById(id);
        if (p == null) return null;
        return new PaymentDTO
        {
            Id = p.Id,
            RentalId = p.RentalId,
            Amount = p.Amount,
            PaymentDate = p.PaymentDate
        };
    }

    public bool Add(PaymentDTO dto)
    {
        var payment = new Payment
        {
            RentalId = dto.RentalId,
            Amount = dto.Amount,
            PaymentDate = DateTime.UtcNow
        };
        return _repo.Add(payment);
    }

    public bool Update(PaymentDTO dto) => false; // תשלומים לא נערכים

    public bool Delete(int id) => _repo.Delete(id);
}