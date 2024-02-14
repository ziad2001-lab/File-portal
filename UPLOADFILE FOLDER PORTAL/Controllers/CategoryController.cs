using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
//using System.Web.Mvc;
using UPLOADFILE_FOLDER_PORTAL.Data;
using UPLOADFILE_FOLDER_PORTAL.Models;

namespace UPLOADFILE_FOLDER_PORTAL.Controllers
{
    [Authorize]

    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            List<Category> categories = _context.Category.ToList();

            return View(categories);
            //return PartialView(categories);
        }
        //[System.Web.Mvc.ChildActionOnly]
        //public IActionResult test()
        //{
        //        List<Category> categories = _context.Category.ToList();

        //    return PartialView(categories);
        //}
        
    public IActionResult Create()
    {
        return View();
    }
     
    // POST: /Category/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Category category)
    {
         
            category.Createdby= User.Identity.Name; //User.Identity.Name;
            category.Createddate = DateTime.Now;
            category.RoleId = "1";
            category.DepartmentId = 4;
            category.IsVisable=true;
            category.IsActive=true;
            bool categoryExists = _context.Category.Any(c => c.RoleId == category.RoleId && c.Name == category.Name && c.IsVisable == true);

            if (categoryExists)
            {
                // Handle the case where a category with the same RoleId and Name already exists
                //ModelState.AddModelError("Category Name", "A category with this RoleId and Name already exists.");
                ViewBag.ErrorMessage = "A category with this Name already exists.";
                ModelState.AddModelError(string.Empty, "A category with this  Name already exists.");

                return View(category);
            }

            
            // Assuming Category model has a property "Cname" for the category name
            _context.Category.Add(category);
            _context.SaveChanges();
        return RedirectToAction("Index"); // Redirect to the category list page


    }
        public IActionResult CategoryDetail(int id)
        {
        //    var category = _context.Category
        //.Include(c => c.Id) // Include related folders
        //.FirstOrDefault(c => c.Id == id);

        //    if (category == null)
        //    {
        //        return NotFound();
        //    }

            return View();
        }

    }
}
