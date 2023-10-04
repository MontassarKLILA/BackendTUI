
using SharedLib.Models;


namespace SharedLib.BusinessLayer.Products
{
    public interface IProductServices
    {
        Task<List<Product>> GetAllProducts();

        Task<Product> GetProductByUid(string uid);
        Task<Product> GetProductByName(string name);
    }
}
