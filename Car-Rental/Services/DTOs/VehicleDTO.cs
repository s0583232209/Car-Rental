using System;
using System.Collections.Generic;
using System.Text;

namespace Services.DTOs
{
    public class VehicleDTO
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public int DailyPrice { get; set; }
        public string LicensePlate { get; set; }


    }
}
