using System.ComponentModel.DataAnnotations;

namespace TalabaMVC.Models
{
    public class RegisterUserDto
    {
        [Required(ErrorMessage = "Firstname Name is required")]
        public string Firstname { get; set; }

        [Required(ErrorMessage = "Firstname Name is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
    }
}
