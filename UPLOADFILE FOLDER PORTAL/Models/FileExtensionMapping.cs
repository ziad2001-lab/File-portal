using System.ComponentModel.DataAnnotations;

namespace UPLOADFILE_FOLDER_PORTAL.Models
{
    public class FileExtensionMapping
    {
        [Key]
        public int Id { get; set; }
        
        public string? Extension { get; set; }
        public string ?ImageUrl { get; set; }
    }
}
