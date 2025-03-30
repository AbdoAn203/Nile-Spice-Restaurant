using Microsoft.AspNetCore.Mvc;
using MyResturant.Models;
namespace MyResturant.Controllers
{
    public class CustomerController : Controller
    {
        ResturantContext context;
        public CustomerController()
        {
            context = new ResturantContext();
        }
        public IActionResult Index()
        {
            List<Product>? top3 = context.Products.OrderByDescending(p => p.Rate).Take(3).ToList();
            return View(top3);
        }
        public IActionResult ShowMenu() {
            List<Product> products = context.Products.ToList();
            return View(products);
        }
        public IActionResult ShowProfile()
        {
            var currentUserId = HttpContext.Session.GetInt32("UserId");
            User? user = context.Users.SingleOrDefault(u => u.Id == currentUserId);
            return View(user);
        }
    }
}
