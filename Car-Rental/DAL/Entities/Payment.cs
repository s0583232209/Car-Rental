using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Payment
    {
        public int Id { get; set; }

        public int RentalId { get; set; }
        public Rental Rental { get; set; }

        public decimal TotalPrice { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
