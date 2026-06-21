using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Interfaces;
using Infrastructure;
namespace Services.Classes
{
    public class CustomerSerivce : IService<CustomerDTO>
    {
        public CustomerDTO Add(VehicleDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<CustomerDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public CustomerDTO GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
