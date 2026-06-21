using System;
using System.Collections.Generic;
using System.Text;

namespace Services.DTOs
{
    public class PaymentDTO
    {
        public int Id { get; set; }
        public RentalDTO Rental { get; set; }
        public float TotalPrice { get; set; }
        public DateTime PaymentDate { get;  set; }

    }
}
