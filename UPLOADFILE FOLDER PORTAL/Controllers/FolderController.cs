using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using UPLOADFILE_FOLDER_PORTAL.Data;
using UPLOADFILE_FOLDER_PORTAL.Models;
using X.PagedList;

namespace UPLOADFILE_FOLDER_PORTAL.Controllers
{
    [Authorize]

    public class FolderController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FolderController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index(int categoryId,string searchQuery, int? page)
        {
            //var Folder = _context.Folder
            //    .Include(c => c.category) // Include related folders
            //    .Where(c => c.CategoryId == categoryId).ToList();
            int pageSize = 12; // Set your desired page size here
            int pageNumber = page ?? 1; // If no page is specified, default to page 1
        
            // Your existing query
            var query = _context.Folder
          .Include(c => c.category)
          .Where(c => c.CategoryId == categoryId && c.IsVisable);

            // Apply search if a query is provided
            if (!string.IsNullOrEmpty(searchQuery))
            {
                query = query.Where(f => f.FolderName.Contains(searchQuery));
            }

            var folders = query.ToPagedList(pageNumber, pageSize);

            ViewBag.CategoryName = _context.Category
                .Where(c => c.Id == categoryId)
                .Select(c => c.Name)
                .FirstOrDefault();

            ViewBag.CategoryName = _context.Category
            .Where(c => c.Id == categoryId)
            .Select(c => c.Name)
            .FirstOrDefault();

            // Store the current search query in ViewBag for use in the view
            ViewBag.CurrentFilter = searchQuery;
            ViewBag.CategoryId = categoryId;
            ViewBag.PagegoryId=page;
           
            return View(folders);
        }
        [HttpGet]
        public IActionResult Create(int categoryId)
        {
            //var category = _context.Folder
            //   .Include(c => c.category).FirstOrDefault(c => c.CategoryId == categoryId);
            var cat = _context.Category.ToList();
            ViewBag.Category = cat;
            ViewBag.CategoryId = categoryId;

            ViewBag.ErrorMessage = TempData["ErrorMessage"] as string;

            return View();
        }



        // POST: /folder/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Folder folder)
        {

           

            bool FolderExists = _context.Folder.Any(c => c.CategoryId == folder.CategoryId && c.FolderName == folder.FolderName && c.IsVisable==true);
            var cat = _context.Category.ToList();
            ViewBag.Category = cat;
            if (FolderExists)
            {
                // Handle the case where a folder with the same   Name already exists
                ViewBag.ErrorMessage = "A folder with this Name already exists.";
                ModelState.AddModelError("FolderName", "A folder with this name already exists.");
                TempData["errormessage"] = "a folder with this name already exists.";

                return RedirectToAction("Create", "Folder", new { categoryId = folder.CategoryId });

            }
            folder.Createdby = User.Identity.Name; //User.Identity./;
            folder.Createddate = DateTime.Now;
            folder.IsVisable = true;
            folder.IsActive = true;
            //folder.CategoryId =;

            // Assuming Category model has a property "Cname" for the category name
            _context.Folder.Add(folder);
            _context.SaveChanges();

            return RedirectToAction("Index", new { categoryId = folder.CategoryId });


            //return View(category); // If model state is not valid, return to the create page with validation errors
        }
        //[ValidateAntiForgeryToken]
        public IActionResult Edit(int id, int categoryId)
        {
            ViewBag.CategoryId= categoryId;
            ViewBag.ErrorMessage = TempData["ErrorMessage"] as string;
            TempData.Clear();

            return View();
            //  ViewBag.id = id;

            //if (ModelState.IsValid)
            //{
            //    return View();

            //}
            //else
            //{
            //    ViewBag.ErrorMessage = "A category with this Name already exists.";
            //    return View();

            //}
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(Folder folder)
        {
            // Check if a folder with the new name already exists
            var newname = folder.FolderName;
            var folderdetail = _context.Folder.FirstOrDefault(f => f.Id == folder.Id);
        //    var catid = folder.CategoryId;
            bool FolderExists = _context.Folder.Any(c => c.CategoryId == folderdetail.CategoryId && c.FolderName == folder.FolderName && c.IsVisable == true);

            if (FolderExists)
            {
                // Update the name if it's unique or if it's the same folder

                ModelState.AddModelError("FolderName", "A folder with this name already exists.");
                TempData["errormessage"] = "a folder with this name already exists.";
                return RedirectToAction("Edit", "Folder", new { categoryId = folderdetail.CategoryId });

            }
            else 
            {
                folderdetail.Modifiedby = User.Identity.Name;
                folderdetail.FolderName = newname;
                folderdetail.Modifieddate = DateTime.Now;
                _context.SaveChanges();
                return RedirectToAction("Index", "Folder", new { categoryId = folderdetail.CategoryId });
            }
           


            //else
            //{

            //    // Handle the case where the new name already exists
            //    // You can throw an exception, return a status, or handle it in another way
            //    // For example, you might want to set a ModelState error if this is part of a controller action
            //    // ModelState.AddModelError("FolderName", "A folder with this name already exists.");
            //}
        }
        //[HttpPost]
        public IActionResult Delete(int folderId)
        {
            var folder = _context.Folder.FirstOrDefault(f => f.Id == folderId);
            if (folder.IsVisable == true)
            {
                folder.IsVisable = false;
            }
                _context.SaveChanges();
            return RedirectToAction("Index", "Folder", new { categoryId = folder.CategoryId });
        }

        public IActionResult Info(int  folderId)
        {
            var folder = _context.Folder.FirstOrDefault(f => f.Id == folderId);

            return View(folder);
        }

    }
}
