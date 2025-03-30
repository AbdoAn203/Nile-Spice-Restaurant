using Microsoft.AspNetCore.Mvc.Formatters;
using MyResturant.Models;
using System.ComponentModel.DataAnnotations;

namespace MyResturant.CustomAttribute
{
    public class UniqueAttribute : ValidationAttribute
    {
        ResturantContext context;
        public UniqueAttribute()
        {
            context = new ResturantContext();
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string email = value as string;
            if (email == null) return ValidationResult.Success;

            User? user = context.Users.FirstOrDefault(u => u.Email == email);
            if (user == null) return ValidationResult.Success;

            return new ValidationResult("Email address is used before");
        }

    }
}
