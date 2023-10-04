using SharedLib.BusinessLayer.CustomerFiles;
using Microsoft.AspNetCore.Mvc;
using SharedLib.Models;
using SharedLib.BusinessLayer.Customers;
using SharedLib.BusinessLayer.Products;
using System.Collections.Generic;

namespace CustomerFileAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerFilesController : ControllerBase
    {
        private readonly ICustomerFileServices _customerFileManager;
        private readonly ICustomerServices _customerManager;
        private readonly IProductServices _productManager;

        public CustomerFilesController(ICustomerFileServices customerFileManager, ICustomerServices customerServices, IProductServices productServices)
        {
            _customerFileManager = customerFileManager;
            _customerManager = customerServices;
            _productManager = productServices;
        }


        // GET: api/<CustomerFilesController>
        [HttpGet]
        public async Task<ActionResult<List<CustomerFile>>> GetAll()
        {
            return await _customerFileManager.GetAllCustomerFiles();
        }

        // GET api/<CustomerFilesController>/customer_firstname/customer_lastname
        [HttpGet("{customer_firstname}/{customer_lastname}")]
        public async Task<ActionResult<CustomerFile>> GetCustomerFileByCustomerName(string customer_firstname, string customer_lastname)
        {
            Customer? cus = await _customerManager.GetCustomersByName(customer_firstname, customer_lastname);
            if (cus == null) { return new NotFoundResult(); }

            CustomerFile cf = await _customerFileManager.GetCustomersFileByCustomerName(cus.uid);
            if (cf.hoteluid == null) { return new NotFoundResult(); }

            Product? ho = await _productManager.GetProductByUid(cf.hoteluid);
            cf.customer = cus;
            cf.hotel = ho;
            return cf;
        }
    }
}