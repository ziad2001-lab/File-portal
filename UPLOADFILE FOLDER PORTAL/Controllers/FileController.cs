using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UPLOADFILE_FOLDER_PORTAL.Data;
using UPLOADFILE_FOLDER_PORTAL.Models;
using X.PagedList;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace UPLOADFILE_FOLDER_PORTAL.Controllers
{
    [Authorize]

    public class FileController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IHostingEnvironment _hostingEnvironment;

        public FileController(ApplicationDbContext context, IHostingEnvironment hostingEnvironment)
        {
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index(int folderId, string searchQuery, int ?page)
        {
            int pageSize = 10; // Set your desired page size here
            int pageNumber = page ?? 1; // If no page is specified, default to page 1

            var filesWithMapping = _context.Files
                .Include(c => c.Folder) // Include related folders
                .Include(c => c.FileExtensionMapping) // Include related FileExtensionMapping
                .Where(c => c.FolderId == folderId);

            if (!string.IsNullOrEmpty(searchQuery))
            {
                filesWithMapping = filesWithMapping.Where(f => f.FileName.Contains(searchQuery));
            }

            var pagedFiles = filesWithMapping.OrderBy(c => c.Id)
                                               .ToPagedList(pageNumber, pageSize);

            ViewBag.FolderId = folderId;
            ViewBag.FolderName= _context.Folder
            .Where(c => c.Id == folderId)
            .Select(c => c.FolderName)
            .FirstOrDefault();

            return View(pagedFiles);
        }
        [HttpGet]
        public IActionResult Create(int folderid)
        {

            ViewBag.FolderId = folderid;
            ViewBag.ErrorMessage= TempData["ErrorMessage"]  ;
            
            return View();
        }
        [HttpPost]
        public IActionResult Create(Files file)
        {
            try
            {
                var extension = Path.GetExtension(file.FileUpload.FileName)?.ToLower();
                if (file.FileUpload != null && file.FileUpload.Length > 0)
                {
                    // Save the file to the wwwroot/Files folder or any other location
                    var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "Files", file.FileUpload.FileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        file.FileUpload.CopyTo(stream);
                    }

                    // Set FilePath property to the relative path within wwwroot
                    file.FilePath = Path.Combine("Files", file.FileUpload.FileName);



                    // Handle the rest of your logic (e.g., updating database, redirecting, etc.)
                }

                // Check if a file with the same name already exists in the folder
                bool fileExists = _context.Files.Any(c => c.FolderId == file.FolderId && c.FileName == file.FileUpload.FileName && c.IsVisable == true);
                if (fileExists)
                {
                    // Update the name if it's unique or if it's the same folder
                    ModelState.AddModelError("FileName", "A file with this name already exists.");
                    TempData["ErrorMessage"] = "A file with this name already exists.";
                    return RedirectToAction("Create", "File", new { FolderId = file.FolderId });
                }

                // Populate additional properties before saving to the database
                file.FileName = file.FileUpload.FileName;
                file.Createdby = User.Identity.Name;
                file.Createddate = DateTime.Now;
                file.IsVisable = true;
                file.IsActive = true;
                file.Modifiedby = "";
                file.Modifieddate = null;

                // Get the FileExtensionMappingId based on the file extension
                file.FileExtensionMappingId = _context.FileExtensionMappings
                    .Where(mapping => mapping.Extension == extension)
                    .Select(mapping => mapping.Id)
                    .FirstOrDefault();

                // Save the Files model to the database or perform other operations as needed
                _context.Files.Add(file);
                _context.SaveChanges();

                return RedirectToAction("Index", new { FolderId = file.FolderId });
            }
            catch (Exception ex)
            {
                ViewBag.message = "ERROR:" + ex.Message.ToString();
                throw; // Consider logging the exception or handling it more gracefully
            }
        }

        public IActionResult Download(int fileId)
        {
            var file = _context.Files.FirstOrDefault(f => f.Id == fileId);

    if (file == null)
    {
        return NotFound();
    }

    // Construct the full file path within the wwwroot folder
    var filePath = Path.Combine(_hostingEnvironment.WebRootPath, file.FilePath);

    if (string.IsNullOrEmpty(file.FilePath) || !System.IO.File.Exists(filePath))
    {
        return NotFound();
    }

    // Serve the file for download
    return PhysicalFile(filePath, "application/octet-stream", file.FileName);
        }
        public IActionResult Edit(int fileId)
        {
            Files ?file = _context.Files.Find(fileId);
            ViewBag.ErrorMessage = TempData["ErrorMessage"];
            ViewBag.FolderId = _context.Files
            .Where(c => c.Id == fileId)
            .Select(c => c.FolderId)
            .FirstOrDefault(); 
            return View(file);
        }
        [HttpPost]
        public IActionResult Edit(Files file)
        {
            // Files file = _context.Files.Find();
            string newname = file.FileName;
          //  var filedetail = _context.Files.FirstOrDefault(f => f.Id == file.Id);
            var originalFile = _context.Files.Find(file.Id);
            var extension = Path.GetExtension(originalFile.FileName);
            string NewNameExtension= file.FileName + extension;
            bool FileExists = _context.Files.Any(c => c.FolderId == file.FolderId && c.FileName == NewNameExtension && c.IsVisable == true);
            if (FileExists)
            {
                // Update the name if it's unique or if it's the same folder
                ModelState.AddModelError("FileName", "A file with this name already exists.");
                TempData["ErrorMessage"] = "a file with this name already exists.";
                return RedirectToAction("Edit", "File", new { FIleId = file.Id });


            }
            else
            {
                //filedetail.FileName = newname;
                originalFile.FileName = file.FileName + extension;
                originalFile.Modifiedby=User.Identity.Name;
                originalFile.Modifieddate= DateTime.Now;    
                _context.SaveChanges();
                return RedirectToAction("Index",new { FolderId = file.FolderId });
                // Handle the case where the new name already exists
                // You can throw an exception, return a status, or handle it in another way
                // For example, you might want to set a ModelState error if this is part of a controller action
                // ModelState.AddModelError("FolderName", "A folder with this name already exists.");
            }
          
        }
        public IActionResult Info(int fileid)
        {
            var file = _context.Files.FirstOrDefault(f => f.Id == fileid);

            return View(file);
        }
        public IActionResult Delete(int fileId)
            {
            
            try
            {
                var file = _context.Files.FirstOrDefault(f => f.Id == fileId);
                file.IsVisable = false;
                _context.SaveChanges();
                return RedirectToAction("Index", new { FolderId = file.FolderId });
            }
            catch (Exception ex)
            {
                ViewBag.message = "ERROR:" + ex.Message.ToString();
                throw;
            }
        }

        
       
            
            
        


    }
}
