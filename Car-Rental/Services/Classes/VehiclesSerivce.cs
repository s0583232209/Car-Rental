using DAL.Interfaces;
using DAL.Entities;
using Services.DTOs;
using Services.Interfaces;
namespace Services.Classes;

public class VehiclesService : IService<VehicleDTO>
{
    private readonly IRepository<Vehicle> _repo;

    public VehiclesService(IRepository<Vehicle> repo) => _repo = repo;

    public List<VehicleDTO> GetAll()
    {
        return _repo.GetAll().Select(v => new VehicleDTO
        {
            Id = v.Id,
            Manufacturer = v.Manufacturer,
            Model = v.Model,
            Year = v.Year,
            LicensePlate = v.LicensePlate,
            DailyPrice = v.DailyPrice
        }).ToList();
    }

    public VehicleDTO GetById(int id)
    {
        var v = _repo.GetById(id);
        if (v == null) return null;
        return new VehicleDTO
        {
            Id = v.Id,
            Manufacturer = v.Manufacturer,
            Model = v.Model,
            Year = v.Year,
            LicensePlate = v.LicensePlate,
            DailyPrice = v.DailyPrice
        };
    }

    public bool Add(VehicleDTO dto)
    {
        var vehicle = new Vehicle
        {
            Manufacturer = dto.Manufacturer,
            Model = dto.Model,
            Year = dto.Year,
            LicensePlate = dto.LicensePlate,
            DailyPrice = dto.DailyPrice
        };
        return _repo.Add(vehicle);
    }

    public bool Update(VehicleDTO dto)
    {
        var vehicle = new Vehicle
        {
            Id = dto.Id,
            Manufacturer = dto.Manufacturer,
            Model = dto.Model,
            Year = dto.Year,
            LicensePlate = dto.LicensePlate,
            DailyPrice = dto.DailyPrice
        };
        return _repo.Update(vehicle);
    }

    public bool Delete(int id) => _repo.Delete(id);

    VehicleDTO IService<VehicleDTO>.Add(VehicleDTO entity)
    {
        throw new NotImplementedException();
    }
}