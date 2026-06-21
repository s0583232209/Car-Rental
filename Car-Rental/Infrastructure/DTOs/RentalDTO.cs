using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DTOs
{
    public class RentalDTO
    {
        public int Id { get; private set; }
        public  CustomerDTO Customer { get; set; }
        public CarDTO Car{ get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate{ get; set; }
      
        public RentalDTO()
        {
            
        }

    }
}
