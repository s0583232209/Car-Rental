using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Interfaces;
using Infrastructure;
using Infrastructure.DTOs;
namespace Services.Classes
{
    public class VehiclesSerivce : IService<VehicleDTO>
    {
        public VehicleDTO Add(VehicleDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<VehicleDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public VehicleDTO GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
