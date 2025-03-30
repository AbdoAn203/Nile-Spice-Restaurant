using Microsoft.AspNetCore.Mvc;
using MyResturant.Models;
using MyResturant.ViewModels;
using System.Diagnostics;

namespace MyResturant.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        ResturantContext context;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            context = new ResturantContext();
        }


        public IActionResult Index()
        {
            List<Product>? top3 = context.Products.OrderByDescending(p => p.Rate).Take(3).ToList();
            return View(top3);
        }
        public IActionResult ShowMenu()
        {
            List<Product> products = context.Products.ToList(); 
            return View(products);
        }
        [HttpGet]
        public IActionResult Login() {
            return View();
        }
        

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginVM loginVM) {
            if (ModelState.IsValid)
            {
                User? user = context.Users.SingleOrDefault(u => u.Email == loginVM.Email);
                if (user == null) { return NotFound(); }
                HttpContext.Session.SetInt32("UserId", user.Id);
                if (user.RoleId == 1) return RedirectToAction("Index", "Admin");
                if (user.RoleId == 2) return RedirectToAction("Index", "Employee");
                if (user.RoleId == 3) return RedirectToAction("Index", "Customer");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Register() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryTokenAttribute]
        public IActionResult Register(RegisterCustomerVM cust)
        {
            if (ModelState.IsValid)
            {
                User customer = new User()
                {
                    Name = cust.Name,
                    Email = cust.Email,
                    Password = cust.Password,
                    Image = cust.Image,
                    RoleId = cust.RoleId,
                    BirthDate = cust.BirthDate,
                };
                context.Users.Add(customer);
                context.SaveChanges();
                HttpContext.Session.SetInt32("UserId", customer.Id);
                return RedirectToAction("Index", "Customer");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Signout() {
            HttpContext.Session.Remove("UserId");
            return RedirectToAction("Index", "Home");
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
