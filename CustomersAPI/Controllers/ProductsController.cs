using SharedLib.BusinessLayer.Products;
using Microsoft.AspNetCore.Mvc;
using SharedLib;
using SharedLib.Models;
using System.Collections.Generic;
using NuGet.Protocol;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TravelAgencyApis.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductServices _productManager;
        private readonly IProductPhotoServices _photosManager;

        public ProductsController(IProductServices productManager, IProductPhotoServices photosManager)
        {
            _productManager = productManager;
            _photosManager = photosManager;
        }


        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetAll()
        {   
            return  await _productManager.GetAllProducts();
        }

        // GET api/<ProductsController>/name
        [HttpGet("{name}")]
        public async Task<ActionResult<Product>> GetProductByName(string name)
        {
            Product? pr = await _productManager.GetProductByName(name);
           
            if (pr == null)
            {
                return NotFound();
            };   

            return pr;
        }

      
    }
}
