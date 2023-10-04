using Microsoft.EntityFrameworkCore;
using SharedLib.Models;
using System.Xml.Linq;

namespace SharedLib.BusinessLayer.Products
{
    public class ProductServices : IProductServices
    {
        private readonly AppCtx _context;
        private readonly IProductPhotoServices _photosManager;

        public ProductServices(AppCtx context, IProductPhotoServices photosManager)
        {
            _context = context;
            _photosManager = photosManager;

        }
        public async Task<List<Product>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductByName(string name)
        {
            Product? pr = await _context.Products.Where(c => c.hotel_name.ToLower().Contains(name.ToLower())).FirstAsync();
            List<ProductPhoto>? productPhotos = _photosManager.GetAllHotelPhotosByHotelId(pr.uid);
            pr.photos = productPhotos;
            return pr;
        }

        public async Task<Product> GetProductByUid(string uid)
        {
            Product? pr = await _context.Products.Where(c => c.uid.Equals(uid)).FirstAsync();
            List<ProductPhoto>? productPhotos = _photosManager.GetAllHotelPhotosByHotelId(pr.uid);
            pr.photos = productPhotos;
            return pr;
           
        }
    }
}
