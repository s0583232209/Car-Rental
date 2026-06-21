using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class Rental
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int CarId { get; set; }
        public Car Car { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
