using System.ComponentModel.DataAnnotations;

namespace PresentationLayer.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Numele este obligatoriu.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Prenumele este obligatoriu.")]
        public string? Surname { get; set; }

        [Required(ErrorMessage = "Adresa de email este obligatorie.")]
        [EmailAddress(ErrorMessage = "Adresa de email nu este validă.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Tipul de utilizator este obligatoriu.")]
        public string? UserType { get; set; }

        public string? Group { get; set; }
        public string? Discipline { get; set; }

        [Required(ErrorMessage = "Parola este obligatorie.")]
        [MinLength(8, ErrorMessage = "Parola trebuie să conțină cel puțin 8 caractere.")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Confirmarea parolei este obligatorie.")]
        [Compare("Password", ErrorMessage = "Parolele nu coincid.")]
        public string? ConfirmPassword { get; set; }
    }
}
