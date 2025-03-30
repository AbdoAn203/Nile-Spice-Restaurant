using MyResturant.CustomAttribute;
using System.ComponentModel.DataAnnotations;

namespace MyResturant.ViewModels
{
    public class LoginVM
    {
        public int Id { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email address is required")]
        public string? Email { get; set; }


        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        [MatchEmail(ErrorMessage ="Incorrect password")]
        public string? Password { get; set; }
    }
}
