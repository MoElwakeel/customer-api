using BLL.DTO;
using EF.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Repo
{
   public  class CustomerRepository:RepositoryBase,ICustomerRepository
    {
        
        public CustomerRepository(DBContext dataContextFactory) : base(dataContextFactory)
        {
          
        }

        public async Task<List<CustomerDTO>> GetCustomers()
        {
           
            var Customers=  instance.Customers.ToList();

            var response = Customers.Select(s => new CustomerDTO(s)).ToList();
            return response;
        }
        public async Task<bool> Update(CustomerDTO customer)
        {

            bool updated = false; ;
            var obj = new Customer()
            {
                Id=customer.Id,
                CustomerName = customer.CustomerName,
                Class = customer.Class,
                Comment = customer.Comment,
                Phone = customer.Phone,
                Email = customer.Email
            };
            
                try
                {
                    if (instance.Entry(obj).State == EntityState.Detached)
                        instance.Set<Customer>().Attach(obj);
                    instance.Entry(obj).State = EntityState.Modified;
                    await instance.SaveChangesAsync();
                updated = true;
                }
                catch (Exception ex)
                {
                    updated = false;
                    
                }
           
            instance.Dispose();
            return updated;
        }
        public async Task<bool> Add(CustomerDTO cstomer)
        {
            var obj = new Customer()
            {
                CustomerName = cstomer.CustomerName,
                Class=cstomer.Class,
                Comment=cstomer.Comment,
                Phone=cstomer.Phone,
                Email=cstomer.Email
            };
            bool IsAdded=false;
            
               
                try
                {
                    instance.Customers.Add(obj);
                    await instance.SaveChangesAsync();
                IsAdded = true;
                }
                catch (Exception ex)
                {
                IsAdded = false;
                    

                }

            
            return IsAdded;
        }
        public async Task<bool> Delete(int id)
        {
           
            bool IsDeleted = false;


            try
            {
               var customer= instance.Customers.Find(id);
                if(customer!=null)
                {
                    instance.Customers.Remove(customer);
                    await instance.SaveChangesAsync();

                }
                IsDeleted = true;
            }
            catch (Exception ex)
            {
                IsDeleted = false;


            }


            return IsDeleted;
        }

    }
    }

