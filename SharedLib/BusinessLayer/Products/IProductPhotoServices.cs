
using SharedLib.Models;


namespace SharedLib.BusinessLayer.Products
{
    public interface IProductPhotoServices
    {
        List<ProductPhoto> GetAllHotelPhotosByHotelId(string hotel_name);
    }
}
