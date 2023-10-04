using System.ComponentModel.DataAnnotations;


namespace SharedLib.Models
{
    public class CustomerFile
    {
        public CustomerFile()
        {
            
        }
        [Key]
        public string uid { get; set; } = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10);

        [Required(ErrorMessage =" La définition d'un client est nécessaire pour créer un dossier")]
        public string? customeruid { get; set; }

        [Required(ErrorMessage = " Le nom de l'hotel est obligatoire pour créer un dossier ")]
        public string? hoteluid { get; set; }

        public Customer? customer { get; set; }

        public Product? hotel { get; set; }

        [Required(ErrorMessage = " La date est obligatoire")]
        public DateTime check_in_date { get; set; }

        [Required(ErrorMessage = " La date est obligatoire")]
        public DateTime check_out_date { get; set; }
 
        public TravelType travel_type { get; set; }

        public string? flight_number { get; set; }

        public DateTime? departure_date { get; set; }

        public DateTime? arrival_date { get; set; }

        public string? destination_country { get; set; }

        public string? destination_city { get; set; }
    }

    public enum TravelType
    {
        Tourisme,
        Affaire,
        Medical,
        Immigration
    }
}
