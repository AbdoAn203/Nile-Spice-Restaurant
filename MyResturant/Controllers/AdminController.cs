using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Identity.Client;
using MyResturant.Models;
using MyResturant.ViewModels;

namespace MyResturant.Controllers
{
    public class AdminController : Controller
    {
        ResturantContext context;
        public AdminController()
        {
            context = new ResturantContext();
        }
        public IActionResult Index()
        {
            List<Product>? top3 = context.Products.OrderByDescending(p => p.Rate).Take(3).ToList();
            return View(top3);
        }
        public IActionResult ShowProfile()
        {
            var currentUserId = HttpContext.Session.GetInt32("UserId");
            User? user = context.Users.SingleOrDefault(u => u.Id == currentUserId);
            return View(user);
        }
        public IActionResult ShowMenu()
        {
            List<Product> products = context.Products.ToList();
            return View(products);
        }
        public IActionResult ShowEmployees()
        {
            List<User> employees = context.Users.Where(u => u.RoleId == 2).ToList();
            return View(employees);
        }
        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddEmployee(RegisterEmployeeVM emp)
        {
            if (ModelState.IsValid)
            {
                User employee = new User()
                {
                    Name = emp.Name,
                    Email = emp.Email,
                    Password = emp.Password,
                    Image = emp.Image,
                    RoleId = emp.RoleId,
                    BirthDate = emp.BirthDate,
                };
                context.Users.Add(employee);
                context.SaveChanges();
                return RedirectToAction("ShowEmployees");
            }
            return View();
        }
        public IActionResult EmpDetails(int id)
        {
            User? user = context.Users.SingleOrDefault(u => u.Id == id);
            return View(user);
        }
        public IActionResult EditEmployee(int id)
        {
            User? emp = context.Users.SingleOrDefault(p => p.Id == id);
            return View(emp);
        }
        [HttpPost]
        public IActionResult EditEmployee(int id,User employee)
        {
             User? emp = context.Users.SingleOrDefault(e => e.Id == id);
             emp.Name = employee.Name;
             emp.Email = employee.Email;
             emp.BirthDate = employee.BirthDate;
             emp.Image = employee.Image;
             context.SaveChanges();
             return RedirectToAction("ShowEmployees");
            
        }

        public IActionResult DeleteEmployee(int id)
        {
            User? emp = context.Users.SingleOrDefault(u=> u.Id == id);
            context.Remove(emp);
            context.SaveChanges();
            return RedirectToAction("ShowEmployees");
        }


        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(ProductVM prod)
        {
            if (ModelState.IsValid)
            {
                Product product = new Product()
                {
                    Name = prod.Name,
                    Price = prod.Price,
                    Rate = prod.Rate,
                    Ingredients = prod.Ingredients,
                    Image = prod.Image,
                };

                context.Products.Add(product);
                context.SaveChanges();
                return RedirectToAction("ShowMenu");
            }
            
            return NotFound();
        }

        public IActionResult EditProduct(int id) { 
            Product? product = context.Products.SingleOrDefault(p => p.Id == id);
            return View(product);
        }
        [HttpPost]
        public IActionResult EditProduct(Product product) {
            if (ModelState.IsValid) { 
                context.Products.Update(product);
                context.SaveChanges();
                return RedirectToAction("ShowMenu");
            }
            return NotFound();
        }

        public IActionResult DeleteProduct(int id) { 
            Product? product = context.Products.SingleOrDefault(product => product.Id == id);
            context.Products.Remove(product);
            context.SaveChanges();
            return RedirectToAction("ShowMenu");
        }
    }
}