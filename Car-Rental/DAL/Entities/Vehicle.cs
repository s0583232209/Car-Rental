using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Vehicle
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string LicensePlate { get; set; }
        public decimal DailyPrice { get; set; }

        public List<Rental> Rentals { get; set; }
    }
}
