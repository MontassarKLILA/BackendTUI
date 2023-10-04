using System.ComponentModel.DataAnnotations;


namespace SharedLib.Models
{
    public class Customer
    {
        public Customer() { 

        }
        [Key]
        public string uid { get; set; } = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10);

        [Required(ErrorMessage = " Le prénom est obligatoire.")]
        [StringLength(20)]
        public string? first_name { get; set; }

        [Required(ErrorMessage = " Le Nom  est obligatoire.")]
        [StringLength(30)]
        public string? last_name { get; set; }

        [Required(ErrorMessage = " La date de naissance est obligatoire.")]
        public DateTime? birthdate { get; set; }

        [Required(ErrorMessage = " L'Email est obligatoire.")]
        [EmailAddress(ErrorMessage = "Le format de l'email est non valide"), RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$")]
        [StringLength(100)]
        public string? email { get; set; }
        public string? phone { get; set; }

        [StringLength(16, MinimumLength = 8, ErrorMessage = "Le mot de passe doit contenir entre 8 et 16 caractères.")]
        public string? password { get; set; }
        
        [Required(ErrorMessage = " L'adresse est obligatoire.")]
        [StringLength(150)]
        public string? address_1 { get; set; }
        public string? address_2 { get; set; }

        [Required(ErrorMessage = " La ville est obligatoire.")]
        [StringLength(50)]
        public string? city { get; set; }

        [Required(ErrorMessage = " Le pays est obligatoire.")]
        [StringLength(20)]
        public string? country { get; set; }

        [Required(ErrorMessage = " Le code postal est obligatoire.")]
        [StringLength(10)]
        public string? zipcode { get; set; }

        public virtual TravelDocument? travel_document { get; set; }

        public string? travel_document_number { get; set; }

    }

    public enum TravelDocument
    {
        Passport,
        CIN
    }
}
