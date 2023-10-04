using System.ComponentModel.DataAnnotations;

namespace SharedLib.Models
{
    public class ProductPhoto
    {
        public ProductPhoto()
        {
                
        }
        [Key]
        public string uid { get; set; } = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10);

        [Required(ErrorMessage = " Il faut attacher la photo à un produit ")]
        public string? productuid { get; set; }
        [Required(ErrorMessage = " L'Email est obligatoire.")]
        public string? meta_title { get; set; }
        public string? meta_description { get; set; }

        [Required(ErrorMessage = " L'url de la photo est obligatoire.")]
        public string? url { get; set; }

        [Required(ErrorMessage = " Le type de la photo est obligatoire.")]
        public PhotoType type { get; set; }

    }

    public enum PhotoType
    {
        Primary,
        Secondary,
        Cover 
    }
}