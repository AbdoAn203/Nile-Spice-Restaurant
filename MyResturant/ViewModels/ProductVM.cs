using System.ComponentModel.DataAnnotations;

namespace MyResturant.ViewModels
{
    public class ProductVM
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public double Rate { get; set; }
        [Required]
        public string Ingredients { get; set; }
        [Required]
        public string Image { get; set; }
    }
}
