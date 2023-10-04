using Microsoft.EntityFrameworkCore;
using SharedLib;
using SharedLib.Models;
using System.Xml.Linq;

namespace SharedLib.BusinessLayer.CustomerFiles
{
    public class CustomerFileServices : ICustomerFileServices
    {
        private readonly AppCtx _context;

        public CustomerFileServices(AppCtx context)
        {
            _context = context;
        }
        public async Task<List<CustomerFile>> GetAllCustomerFiles()
        {
            return await _context.CustomerFiles.ToListAsync();
        }

        public async Task<CustomerFile> GetCustomersFileByCustomerName(string customer_uid)
        {
            return await _context.CustomerFiles.Where(c => c.customeruid.Equals(customer_uid)).FirstAsync();
        }
    }
}
