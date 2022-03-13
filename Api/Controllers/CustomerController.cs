using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _CustomerRepository;

        public CustomerController(ICustomerRepository CustomerRepository)
        {
            _CustomerRepository = CustomerRepository;
        }

        [Produces("application/json")]
        [ProducesResponseType(200, Type = typeof(List<CustomerDTO>))]
        [HttpGet("Get")]
        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {

            var response = await _CustomerRepository.GetCustomers();
           
            
                return Ok(response);
            }

       
        [HttpPost("Add")]
        public async Task<IActionResult> Add(CustomerDTO customer)
        {
            var response = false;
            if (customer.Id != 0)
            {
                response = await _CustomerRepository.Update(customer);
            }
            else
            {

                response = await _CustomerRepository.Add(customer);
            }
            
                return Ok(response);
            
        }

       
        
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var response = await _CustomerRepository.Delete(id);

            return Ok(response);

        }

    }

    }

