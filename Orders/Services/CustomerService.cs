using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Orders.Models;
using System.Linq;

namespace Orders.Services
{
    public class CustomerService : ICustomerService
    {
        private IList<Customer> _customers;

        public CustomerService()
        {
            _customers = new List<Customer>();
            _customers.Add(new Customer(1, "John Smith"));
            _customers.Add(new Customer(2, "James John"));
            _customers.Add(new Customer(3, "Rick James"));
        }

        public Customer GetCustomerById(int id)
        {
            return GetCustomerByIdAsync(id).Result;
        }

        public Task<Customer> GetCustomerByIdAsync(int id)
        {
            return Task.FromResult(_customers.Single(x => Equals(x.Id)));
        }

        public Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            return Task.FromResult(_customers.AsEnumerable());
        }
    }
    public interface ICustomerService
    {
        Customer GetCustomerById(int id);
        Task<Customer> GetCustomerByIdAsync(int id);
        Task<IEnumerable<Customer>> GetCustomersAsync();
    }
}
