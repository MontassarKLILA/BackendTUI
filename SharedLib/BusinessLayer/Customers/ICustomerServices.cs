using SharedLib.Models;


namespace SharedLib.BusinessLayer.Customers
{
    public interface ICustomerServices
    {
        Task<List<Customer>> GetAllCustomers();
        Task<Customer> GetCustomersByName(string first_name, string last_name);
    }
}
