using SharedLib.Models;



namespace SharedLib.BusinessLayer.Products
{
    public class ProductPhotoServices : IProductPhotoServices
    {
        private readonly AppCtx _context;

        public ProductPhotoServices(AppCtx context)
        {
            _context = context;
        }

        public  List<ProductPhoto> GetAllHotelPhotosByHotelId(string hotel_uid)
        {
            List<ProductPhoto> pr = new List<ProductPhoto>();
            if (_context.ProductPhotos != null)
            {
                pr = _context.ProductPhotos.Where(pp => pp.productuid.Equals(hotel_uid)).ToList();
            }

            return pr;
          
        }

       
    }
}
