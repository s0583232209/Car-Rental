using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DTOs
{
    public class PaymentDTO
    {
        public int Id { get;private set; }
        public RentalDTO Rental { get; set; }
        public float TotalPrice { get; set; }
        public DateTime PaymentDate { get; private set; }

    }
}
