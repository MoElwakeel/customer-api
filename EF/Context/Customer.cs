using System;
using System.Collections.Generic;

#nullable disable

namespace EF.Context
{
    public partial class Customer
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Phone { get; set; }
        public string Class { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }
    }
}
