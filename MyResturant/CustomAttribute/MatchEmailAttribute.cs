using MyResturant.Models;
using System.ComponentModel.DataAnnotations;

namespace MyResturant.CustomAttribute
{
    public class MatchEmailAttribute : ValidationAttribute
    {
        ResturantContext context;
        public MatchEmailAttribute()
        {
            context = new ResturantContext();
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {   
            var emailProp = validationContext.ObjectType.GetProperty("Email");
            var email = emailProp.GetValue(validationContext.ObjectInstance) as string;
            string? password = value as string; 
            var user = context.Users.SingleOrDefault(u => u.Email == email);
            if (user == null) { return new ValidationResult("This email address does not exist"); }
            if (user.Password != password) return new ValidationResult("Incorrect Password");
            return ValidationResult.Success;
        }
    }
}
