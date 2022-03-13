using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repo
{
    public interface ICustomerRepository
    {
        Task<List<CustomerDTO>> GetCustomers();
        Task<bool> Add(CustomerDTO cstomer);

         Task<bool> Delete(int id);
        Task<bool> Update(CustomerDTO customer);
    }
}
