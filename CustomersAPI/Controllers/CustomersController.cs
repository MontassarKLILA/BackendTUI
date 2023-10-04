
using SharedLib.BusinessLayer.Customers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedLib;
using SharedLib.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelAgencyApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        private readonly ICustomerServices _customerManager;

        public CustomersController(ICustomerServices customerManager)
        {
            _customerManager = customerManager;
        }


        // GET: api/<CustomersController>
        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetAll()
        {
            return await _customerManager.GetAllCustomers();
        }


        // GET api/<CustomersController>/firstname
        [HttpGet("{firstname}/{lastname}")]
        public async Task<ActionResult<Customer>> GetCustomerByName(string first_name, string last_name)
        {
            return await _customerManager.GetCustomersByName(first_name, last_name);
        }


    }
}
