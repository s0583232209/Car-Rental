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
    public class PaymentsService : IService<PaymentDTO>
    {
        public PaymentDTO Add(PaymentDTO entity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<PaymentDTO> GetAll()
        {
            throw new NotImplementedException();
        }

        public PaymentDTO GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
