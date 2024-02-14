using Microsoft.AspNetCore.Mvc;
using UPLOADFILE_FOLDER_PORTAL.Data;
using UPLOADFILE_FOLDER_PORTAL.Models;

namespace UPLOADFILE_FOLDER_PORTAL.View_companent
{
    public class sidebar:ViewComponent
    {
        private readonly ApplicationDbContext _context;
        public sidebar(ApplicationDbContext context)
        {
            _context = context;

        }   
        public IViewComponentResult Invoke()
        {
            List<Category> categories = _context.Category.ToList();

            return View(categories);
        }

    }
}
