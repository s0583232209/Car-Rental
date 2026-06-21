using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public List<Rental> Rentals { get; set; }
    }
}
