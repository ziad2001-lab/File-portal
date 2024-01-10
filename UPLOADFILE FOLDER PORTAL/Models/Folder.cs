using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UPLOADFILE_FOLDER_PORTAL.Models
{
    public class Folder:BaseClass
    {
        public int CategoryId { get; set; }
        [StringLength(250)]
        public string FolderName { get; set; }
        [StringLength(1000)]
        public string FolderPath { get; set; }
        [StringLength(500)]
        public string? Description { get; set; }
        public int? Main_Folder_Id { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category category { get; set; }

        [ForeignKey("Main_Folder_Id")]
        public virtual Folder folder { get; set; }
    }
}
