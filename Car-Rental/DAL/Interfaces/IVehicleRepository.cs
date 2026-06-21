using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Interfaces;

public interface IVehicleRepository
{
    Task<IEnumerable<Vehicle>> GetAll();
    Task<Vehicle?> GetById(int id);
    Task<IEnumerable<Vehicle>> GetAvailable();
    Task Add(Vehicle vehicle);
    Task Update(Vehicle vehicle);
    Task<IEnumerable<bool>> Delete(int id);
}
