using System.ComponentModel.DataAnnotations.Schema;

namespace MyResturant.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Image {  get; set; }
        public DateOnly BirthDate { get; set; }

        // Foreign Key 
        [ForeignKey("Role")]
        public int RoleId { get; set; }

        // Navigation Prop

        public Role Role { get; set; }


    }
}
