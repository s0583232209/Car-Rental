using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.DTOs
{
    public class CustomerDTO
    {
        public int Id { get; private set; }
        public string  FullName { get; set; }
        public string  Email { get; set; }
        public string Phone { get; set; }
    }
}
