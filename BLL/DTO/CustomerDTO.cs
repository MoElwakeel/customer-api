using EF.Context;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO
{
   public class CustomerDTO
    {

        public int Id { get; set; }
        public string CustomerName { get; set; }
        public string Phone { get; set; }
        public string Class { get; set; }
        public string Email { get; set; }
        public string Comment { get; set; }

        
        public CustomerDTO(Customer CustomerObJ)
        {
            Id = CustomerObJ.Id;
            CustomerName = CustomerObJ.CustomerName;
            Class = CustomerObJ.Class;
            Comment = CustomerObJ.Comment;
            Phone = CustomerObJ.Phone;
            Email = CustomerObJ.Email;
        }

        public CustomerDTO()
        {


        }
    }
}
