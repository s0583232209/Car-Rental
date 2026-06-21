using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DTOs
{
    public class VehicleDTO
    {
        public int Id { get;private set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public float DailyPrice { get; set; }


    }
}
