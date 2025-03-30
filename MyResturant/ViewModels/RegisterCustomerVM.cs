using MyResturant.CustomAttribute;
using System.ComponentModel.DataAnnotations;

namespace MyResturant.ViewModels
{
    public class RegisterCustomerVM
    {
        public RegisterCustomerVM()
        {
            RoleId = 3;
        }
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email address is required")]
        [Unique(ErrorMessage = "Email address is used")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        [MinLength(8, ErrorMessage = "Password must be minimum 8 characters")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Confirm password please")]
        [MinLength(8, ErrorMessage = "Password must be minimum 8 characters")]
        [Compare("Password", ErrorMessage = "Not matched")]
        public string ConfirmPassword { get; set; }



        [Required(ErrorMessage = "Birth date is required")]
        public DateOnly BirthDate { get; set; }


        public int RoleId { get; set; }

        public string Image { get; set; }
    }
}
