using Microsoft.EntityFrameworkCore;
using SharedLib.Models;

namespace SharedLib.BusinessLayer.Customers
{
    public class CustomerServices : ICustomerServices
    {
        private readonly AppCtx _context;

        public CustomerServices(AppCtx context)
        {
            _context = context;
        }
        public async Task<List<Customer>> GetAllCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomersByName(string first_name, string last_name)
        {
            Customer cus = new Customer();
            if ((string.IsNullOrWhiteSpace(first_name)) || (string.IsNullOrEmpty(last_name)))
            {
                return cus;
            }
            else return await _context.Customers.Where(c => c.first_name.ToLower().Equals(first_name.ToLower()) && c.last_name.ToLower().Equals(last_name.ToLower())).FirstAsync();
        }



    }
}
