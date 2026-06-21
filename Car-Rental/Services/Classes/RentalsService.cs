using DAL.Interfaces;
using DAL.Entities;
using Infrastructure.DTOs;
using Services.Interfaces;

namespace Services.Classes;

public class RentalService : IService<RentalDTO>
{
    private readonly IRentalsRepository _repo;
    private readonly IVehicleRepository _vehicles;

    public RentalService(IRentalsRepository repo, IVehicleRepository vehicles)
    {
        _repo = repo;
        _vehicles = vehicles;
    }

    public List<RentalDTO> GetAll()
    {
        return _repo.GetAll().Select(r => new RentalDTO
        {
            Id = r.Id,
            CustomerId = r.CustomerId,
            CarId = r.CarId,
            StartDate = r.StartDate,
            EndDate = r.EndDate,
            TotalPrice = r.TotalPrice
        }).ToList();
    }

    public RentalDTO GetById(int id)
    {
        var r = _repo.GetById(id);
        if (r == null) return null;
        return new RentalDTO
        {
            Id = r.Id,
            CustomerId = r.CustomerId,
            CarId = r.CarId,
            StartDate = r.StartDate,
            EndDate = r.EndDate,
            TotalPrice = r.TotalPrice
        };
    }

    public bool Add(RentalDTO dto)
    {
        var rental = new Rental
        {
            CustomerId = dto.CustomerId,
            CarId = dto.CarId,
            StartDate = DateTime.UtcNow,
            TotalPrice = 0   // יחושב בסגירה
        };
        return _repo.Add(rental);
    }

    public bool Update(RentalDTO dto)
    {
        // סגירת השכרה – חישוב מחיר
        var vehicle = _vehicles.GetById(dto.CarId);
        var days = (int)Math.Ceiling(
            (DateTime.UtcNow - dto.StartDate).TotalDays);
        dto.EndDate = DateTime.UtcNow;
        dto.TotalPrice = days * (vehicle?.DailyPrice ?? 0);

        var rental = new Rental
        {
            Id = dto.Id,
            CustomerId = dto.CustomerId,
            CarId = dto.CarId,
            StartDate = dto.StartDate,
            EndDate = dto.EndDate,
            TotalPrice = dto.TotalPrice
        };
        return _repo.Update(rental);
    }

    public bool Delete(int id) => _repo.Delete(id);
}