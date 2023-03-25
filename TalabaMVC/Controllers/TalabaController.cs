using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Experimental.ProjectCache;
using Microsoft.EntityFrameworkCore;
using TalabaMVC.DBContext;
using TalabaMVC.Models;
using TalabaMVC.Services;

namespace TalabaMVC.Controllers
{
    public class TalabaController : Controller
    {
        AppDbContext context;
        IAuthManager authManager;

        public TalabaController(AppDbContext context, IAuthManager authManager)
        {
            this.context = context;
            this.authManager = authManager;
        }

        public IActionResult List(string token, string searchString, string sortOrder, int currentPage)
        {
            ViewBag.Token = token;
            var validation = authManager.ValidateToken(token).Result;

            if (validation.Status == "Valid" && validation.Roles.Contains("Admin"))
            {
                ViewBag.CreateText = "Create";
                ViewBag.EditText = "Edit";
                ViewBag.DeleteText = "Delete";
            }
            if (validation.Status == "Valid" && (validation.Roles.Contains("Admin") || validation.Roles.Contains("User")) )
            {
                ViewBag.SearchString = searchString;
                ViewBag.SortOrder = sortOrder != "asc" ? "asc" : "desc";
                if (currentPage == 0) currentPage = 1;
                (IEnumerable<Talaba> talabalar, int count) = GetAllTalaba(searchString, sortOrder, currentPage);
                int a = (count + 4) / 5;
                ViewBag.Pages = a;
                 
                return View(talabalar);
            }
            return RedirectToAction("Login", "Account");
        }

        public IActionResult CheckUser(string token)
        {
            var validation = authManager.ValidateToken(token).Result;
            if (validation.Status == "Valid" && validation.Roles.Contains("Admin"))
            {
                ViewBag.Role = validation.Roles[0];
                return RedirectToAction("List");
            }
            return RedirectToAction("Login", "Account");
        }

        public (IEnumerable<Talaba>, int) GetAllTalaba(string? searchString, string? sortOrder, int currentPage)
        {
            IList<Talaba> list = new List<Talaba>();
            switch (sortOrder)
            {
                case "asc":
                    {
                        list = context.Talabalar
                            .Where(p => searchString == null || (p.Name.ToLower().Contains(searchString.ToLower())))
                            .OrderBy(p => p.Name)
                            .ToList();
                        break;
                    }
                case "desc":
                    {
                        list = context.Talabalar
                            .Where(p => searchString == null || (p.Name.ToLower().Contains(searchString.ToLower())))
                            .OrderByDescending(p => p.Name)
                            .ToList();
                        break;
                    }
                default:
                    {
                        list = context.Talabalar
                            .Where(p => searchString == null || (p.Name.ToLower().Contains(searchString.ToLower())))
                            .ToList();
                        break;
                    }
            }
            return (list.Skip((currentPage - 1) * 5).Take(5), list.Count);
        }

        public IActionResult Create(string token)
        {
            ViewBag.Token = token;
            var validation = authManager.ValidateToken(token).Result;
            if (validation.Status == "Valid" && (validation.Roles.Contains("Admin") || validation.Roles.Contains("User")))
            {
                return View();
            }
            return RedirectToAction("Login", "Account");

        }

        public IActionResult Add(Talaba talaba)
        {
            context.Talabalar.Add(talaba);
            context.SaveChanges();
            return RedirectToAction("List");
        }

        public IActionResult Delete(int id)
        {
            var talaba = context.Talabalar.FirstOrDefault(x => x.Id == id);
            return View(talaba);
        }

        public IActionResult Remove(Talaba talaba)
        {
            context.Talabalar.Remove(talaba);
            context.SaveChanges();

            return RedirectToAction("List");
        }

        public IActionResult Details(int Id)
        {
            var talaba = context.Talabalar.FirstOrDefault(p => p.Id == Id);
            return View(talaba);
        }

        public IActionResult Edit(int Id)
        {
            var talaba = context.Talabalar.FirstOrDefault(p => p.Id == Id);
            return View(talaba);
        }

        public IActionResult Update(Talaba talaba)
        {
            var oldTalaba = context.Talabalar.FirstOrDefault(p => p.Id == talaba.Id);
            context.Attach(oldTalaba).CurrentValues.SetValues(talaba);
            context.SaveChanges();

            return RedirectToAction("List");
        }
    }
}
