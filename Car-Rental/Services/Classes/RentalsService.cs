////using DAL.Interfaces;
////using DAL.Entities;
////using Services.Interfaces;
////using Services.DTOs;
////using DAL.Repositories;

////namespace Services.Classes;

////public class RentalService : IService<RentalDTO>
////{
////    private readonly IRepository<Rental> _repo;
////    private readonly IRepository<Vehicle> _vehicles;
////    private readonly IRepository<Customer> customers;

////    public RentalService(IRepository<Rental> repo, IRepository<Vehicle> vehicles, IRepository<Customer> customers)
////    {
////        _repo = repo;
////        _vehicles = vehicles;
////        this.customers = customers;
////    }

////    public List<RentalDTO> GetAll()
////    {
////        return _repo.GetAll().Select(r => new RentalDTO
////        {
////            Id = r.Id,
////            StartDate = r.StartDate,
////            EndDate = r.EndDate ?? DateTime.MinValue,

////            // map nested Customer
////            Customer = r.Customer == null ? null : new CustomerDTO
////            {
////                Id = r.Customer.Id,
////                FullName = r.Customer.FullName,
////                Email = r.Customer.Email,
////                Phone = r.Customer.Phone
////            },

////            // map nested Vehicle
////            Car = r.Car == null ? null : new VehicleDTO
////            {
////                Id = r.Car.Id,
////                Manufacturer = r.Car.Manufacturer,
////                Model = r.Car.Model,
////                Year = r.Car.Year,
////                LicensePlate = r.Car.LicensePlate,
////                DailyPrice = r.Car.DailyPrice
////            }
////        }).ToList();
////    }

////     public RentalDTO GetById(int id)
////    {
////        var r = _repo.GetById(id);
////        if (r == null) return null;
////        Vehicle vehicle = _vehicles.GetById(r.CarId);
////        Customer customer= customers.GetById(r.CustomerId);
////        CustomerDTO cdto= 
////        return new RentalDTO
////        {
////            Id = r.Id,
////            Customer = Customer,
////            CarId = r.CarId,
////            StartDate = r.StartDate,
////            EndDate = r.EndDate,
////        };
////    }

////    public bool Add(RentalDTO dto)
////    {

////        var rental = new Rental
////        {
////            CustomerId = dto.Customer.Id,
////            CarId = dto.Car.Id,
////            StartDate = DateTime.UtcNow,
////            TotalPrice = 0   // יחושב בסגירה
////        };
////        return _repo.Add(rental);
////    }

////    public bool Update(RentalDTO dto)
////    {
////        var vehicle = _vehicles.GetById(dto.Car.Id);

////        var endDate = DateTime.UtcNow;
////        TimeSpan duration = endDate - dto.StartDate;
////        int days = (int)Math.Ceiling(duration.TotalDays);

////        dto.EndDate = endDate;

////        var rental = new Rental
////        {
////            Id = dto.Id,
////            CustomerId = dto.Customer.Id,
////            CarId = dto.Car.Id,
////            StartDate = dto.StartDate,
////            EndDate = dto.EndDate,
////            TotalPrice = days * (vehicle?.DailyPrice ?? 0)
////        };
////        return _repo.Update(rental);
////    }

////    public bool Delete(int id) => _repo.Delete(id);


////}
//using AutoMapper;
//using DAL.Entities;
//using DAL.Interfaces;
//using Services.DTOs;
//using Services.Interfaces;

//namespace Services.Classes;

//public class RentalService : IService<RentalDTO>
//{
//    private readonly IRepository<Rental> _repo;
//    private readonly IRepository<Vehicle> _vehicles;
//    private readonly IRepository<Customer> _customers;
//    private readonly IMapper _mapper;

//    public RentalService(
//        IRepository<Rental> repo,
//        IRepository<Vehicle> vehicles,
//        IRepository<Customer> customers,
//        IMapper mapper)
//    {
//        _repo = repo;
//        _vehicles = vehicles;
//        _customers = customers;
//        _mapper = mapper;
//    }

//    public List<RentalDTO> GetAll()
//    {
//        var rentals = _repo.GetAll();

//        return _mapper.Map<List<RentalDTO>>(rentals);
//    }

//    public RentalDTO? GetById(int id)
//    {
//        var rental = _repo.GetById(id);

//        if (rental == null)
//            return null;

//        return _mapper.Map<RentalDTO>(rental);
//    }

//    public bool Add(RentalDTO dto)
//    {
//        var rental = _mapper.Map<Rental>(dto);

//        rental.StartDate = DateTime.UtcNow;
//        rental.TotalPrice = 0;

//         Rental ren=_repo.Add(rental);
//        if (ren != null) return true;
//        return false;
//    }

//    public bool Update(RentalDTO dto)
//    {
//        var vehicle = _vehicles.GetById(dto.Car.Id);

//        var endDate = DateTime.UtcNow;

//        var days = (int)Math.Ceiling(
//            (endDate - dto.StartDate).TotalDays);

//        dto.EndDate = endDate;

//        var rental = _mapper.Map<Rental>(dto);

//        rental.TotalPrice =
//            days * (vehicle?.DailyPrice ?? 0);

//        return _repo.Update(rental);
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

public class RentalService : IService<RentalDTO>
{
    private readonly IRepository<Rental> _repo;
    private readonly IRepository<Vehicle> _vehicles;
    private readonly IRepository<Customer> _customers;
    private readonly IMapper _mapper;

    public RentalService(
        IRepository<Rental> repo,
        IRepository<Vehicle> vehicles,
        IRepository<Customer> customers,
        IMapper mapper)
    {
        _repo = repo;
        _vehicles = vehicles;
        _customers = customers;
        _mapper = mapper;
    }

    public List<RentalDTO> GetAll()
    {
        var rentals = _repo.GetAll();

        return _mapper.Map<List<RentalDTO>>(rentals);
    }

    public RentalDTO? GetById(int id)
    {
        var rental = _repo.GetById(id);

        if (rental == null)
            return null;

        return _mapper.Map<RentalDTO>(rental);
    }

    public bool Add(RentalDTO dto)
    {
        var rental = _mapper.Map<Rental>(dto);

        rental.StartDate = DateTime.UtcNow;
        //rental.TotalPrice = 0;

     return _repo.Add(rental);
    }

    public bool Update(RentalDTO dto)
    {
        var vehicle = _vehicles.GetById(dto.Car.Id);

        var endDate = DateTime.UtcNow;

        var days = (int)Math.Ceiling(
            (endDate - dto.StartDate).TotalDays);

        dto.EndDate = endDate;

        var rental = _mapper.Map<Rental>(dto);

        //rental.TotalPrice =
        //    days * (vehicle?.DailyPrice ?? 0);

        return _repo.Update(rental);
    }

    public bool Delete(int id)
    {
        return _repo.Delete(id);
    }
}