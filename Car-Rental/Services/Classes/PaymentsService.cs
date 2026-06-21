////using DAL.Interfaces;
////using DAL.Entities;
////using Services.DTOs;
////using Services.Interfaces;

////namespace Services.Classes;

////public class PaymentService : IService<PaymentDTO>
////{
////    private readonly IRepository<Payment> _repo;

////    public PaymentService(IRepository<Payment> repo) => _repo = repo;

////    public List<PaymentDTO> GetAll()
////    {
////        return _repo.GetAll().Select(p => new PaymentDTO
////        {
////            Id = p.Id,
////            RentalId = new Rental(p.RentalId),
////            Amount = p.Amount,
////            PaymentDate = p.PaymentDate
////        }).ToList();
////    }

////    public PaymentDTO GetById(int id)
////    {
////        var p = _repo.GetById(id);
////        if (p == null) return null;
////        return new PaymentDTO
////        {
////            Id = p.Id,
////            RentalId = p.RentalId,
////            Amount = p.Amount,
////            PaymentDate = p.PaymentDate
////        };
////    }

////    public bool Add(PaymentDTO dto)
////    {
////        var payment = new Payment
////        {
////            RentalId = dto.RentalId,
////            Amount = dto.Amount,
////            PaymentDate = DateTime.UtcNow
////        };
////        return _repo.Add(payment);
////    }

////    public bool Update(PaymentDTO dto) => false; // תשלומים לא נערכים

////    public bool Delete(int id) => _repo.Delete(id);
////}
//using AutoMapper;
//using DAL.Entities;
//using DAL.Interfaces;
//using Services.DTOs;
//using Services.Interfaces;

//namespace Services.Classes;

//public class PaymentService : IService<PaymentDTO>
//{
//    private readonly IRepository<Payment> _repo;
//    private readonly IMapper _mapper;

//    public PaymentService(
//        IRepository<Payment> repo,
//        IMapper mapper)
//    {
//        _repo = repo;
//        _mapper = mapper;
//    }

//    public List<PaymentDTO> GetAll()
//    {
//        var payments = _repo.GetAll();

//        return _mapper.Map<List<PaymentDTO>>(payments);
//    }

//    public PaymentDTO? GetById(int id)
//    {
//        var payment = _repo.GetById(id);

//        if (payment == null)
//            return null;

//        return _mapper.Map<PaymentDTO>(payment);
//    }

//    public bool Add(PaymentDTO dto)
//    {
//        var payment = _mapper.Map<Payment>(dto);

//        payment.PaymentDate = DateTime.UtcNow;

//        Payment py=_repo.Add(payment);
//        if (py != null) return true;
//        return false;
//    }

//    public bool Update(PaymentDTO dto)
//    {
//        // אם לא מאפשרים עריכת תשלומים
//        return false;
//    }

//    public bool Delete(int id)
//    {
//        return _repo.Delete(id);
//    }
//}
using AutoMapper;
using DAL.Entities;
using DAL.Interfaces;
using Services.DTOs;
using Services.Interfaces;

namespace Services.Classes;

public class PaymentService : IService<PaymentDTO>
{
    private readonly IRepository<Payment> _repo;
    private readonly IMapper _mapper;

    public PaymentService(
        IRepository<Payment> repo,
        IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public List<PaymentDTO> GetAll()
    {
        return _mapper.Map<List<PaymentDTO>>(
            _repo.GetAll());
    }

    public PaymentDTO? GetById(int id)
    {
        var payment = _repo.GetById(id);

        return payment == null
            ? null
            : _mapper.Map<PaymentDTO>(payment);
    }

    public bool Add(PaymentDTO dto)
    {
        var payment = _mapper.Map<Payment>(dto);

        payment.PaymentDate = DateTime.UtcNow;

        return  _repo.Add(payment);

    }

    public bool Update(PaymentDTO dto)
    {
        return false;
    }

    public bool Delete(int id)
    {
        return _repo.Delete(id);
    }
}