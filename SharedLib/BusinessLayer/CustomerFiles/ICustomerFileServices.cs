
using SharedLib.Models;
using System.Numerics;

namespace SharedLib.BusinessLayer.CustomerFiles
{
    public interface ICustomerFileServices
    {
        Task<List<CustomerFile>> GetAllCustomerFiles();
        Task<CustomerFile> GetCustomersFileByCustomerName(string firstname);
    }
}
