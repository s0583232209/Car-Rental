using System;
using System.Collections.Generic;
using System.Text;

namespace Services.DTOs
{
    public class CustomerDTO
    {
        public int Id { get;  set; }
        public string  FullName { get; set; }
        public string  Email { get; set; }
        public string Phone { get; set; }
    }
}
