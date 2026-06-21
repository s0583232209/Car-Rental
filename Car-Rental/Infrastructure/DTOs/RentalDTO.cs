using System;
using System.Collections.Generic;
using System.Text;

namespace Services.DTOs
{
    public class RentalDTO
    {
        public int Id { get; private set; }
        public CustomerDTO Customer { get; set; }
        public VehicleDTO Car{ get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate{ get; set; }
      
        

    }
}
