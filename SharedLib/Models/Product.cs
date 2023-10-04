using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace SharedLib.Models
{
    public class Product
    {
        public Product()
        {
            this.photos = new List<ProductPhoto>();
        }
        [Key]
        public string uid { get; set; } = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10);

        [Required(ErrorMessage = " Le nom de l'hotel est obligatoire pour créer un dossier ")]
        public string? hotel_name { get; set; }
        public string? hotel_description { get; set; }
        public int? stars { get; set; }
        public virtual ICollection<ProductPhoto>? photos { get; set; }
        public int? total_capacity { get; set; }
    }
}
