using MyResturant.Models;
using System.ComponentModel.DataAnnotations;

namespace MyResturant.CustomAttribute
{
    public class MatchDBAttribute : ValidationAttribute
    {
        ResturantContext context;
        public MatchDBAttribute()
        {
            context = new ResturantContext();
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string? email = value as string;
            User? user = context.Users.SingleOrDefault(u => u.Email == email);
            if (user == null) { return new ValidationResult("This email address doesn't exist."); }
            return ValidationResult.Success;
        }
    }
}
