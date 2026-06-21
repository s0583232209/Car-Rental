//using DAL.Interfaces;
//using DAL.Entities;
//using Services.DTOs;
//using Services.Interfaces;
//namespace Services.Classes;

//public class VehiclesService : IService<VehicleDTO>
//{
//    private readonly IRepository<Vehicle> _repo;

//    public VehiclesService(IRepository<Vehicle> repo) => _repo = repo;

//    public List<VehicleDTO> GetAll()
//    {
//        return _repo.GetAll().Select(v => new VehicleDTO
//        {
//            Id = v.Id,
//            Manufacturer = v.Manufacturer,
//            Model = v.Model,
//            Year = v.Year,
//            LicensePlate = v.LicensePlate,
//            DailyPrice = v.DailyPrice
//        }).ToList();
//    }

//    public VehicleDTO GetById(int id)
//    {
//        var v = _repo.GetById(id);
//        if (v == null) return null;
//        return new VehicleDTO
//        {
//            Id = v.Id,
//            Manufacturer = v.Manufacturer,
//            Model = v.Model,
//            Year = v.Year,
//            LicensePlate = v.LicensePlate,
//            DailyPrice = v.DailyPrice
//        };
//    }

//    public VehicleDTO Add(VehicleDTO dto)
//    {
//        var vehicle = new Vehicle
//        {
//            Manufacturer = dto.Manufacturer,
//            Model = dto.Model,
//            Year = dto.Year,
//            LicensePlate = dto.LicensePlate,
//            DailyPrice = dto.DailyPrice
//        };
//        return _mapper._repo.Add(vehicle);
//    }

//    public bool Update(VehicleDTO dto)
//    {
//        var vehicle = new Vehicle
//        {
//            Id = dto.Id,
//            Manufacturer = dto.Manufacturer,
//            Model = dto.Model,
//            Year = dto.Year,
//            LicensePlate = dto.LicensePlate,
//            DailyPrice = dto.DailyPrice
//        };
//        return _repo.Update(vehicle);
//    }

//    public bool Delete(int id) => _repo.Delete(id);

//    VehicleDTO IService<VehicleDTO>.Add(VehicleDTO entity)
//    {
//        throw new NotImplementedException();
//    }
//}
using AutoMapper;
using DAL.Entities;
using DAL.Interfaces;
using Services.DTOs;
using Services.Interfaces;

namespace Services.Classes;

public class VehiclesService : IService<VehicleDTO>
{
    private readonly IRepository<Vehicle> _repo;
    private readonly IMapper _mapper;

    public VehiclesService(
        IRepository<Vehicle> repo,
        IMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public List<VehicleDTO> GetAll()
    {
        var vehicles = _repo.GetAll();

        return _mapper.Map<List<VehicleDTO>>(vehicles);
    }

    public VehicleDTO? GetById(int id)
    {
        var vehicle = _repo.GetById(id);

        if (vehicle == null)
            return null;

        return _mapper.Map<VehicleDTO>(vehicle);
    }

    public bool Add(VehicleDTO dto)
    {
        var vehicle = _mapper.Map<Vehicle>(dto);

        return _repo.Add(vehicle);
      

    }

    public bool Update(VehicleDTO dto)
    {
        var vehicle = _mapper.Map<Vehicle>(dto);

        return _repo.Update(vehicle);
    }

    public bool Delete(int id)
    {
        return _repo.Delete(id);
    }
}