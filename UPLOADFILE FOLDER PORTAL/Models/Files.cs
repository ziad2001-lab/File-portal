using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UPLOADFILE_FOLDER_PORTAL.Models
{
    public class Files :BaseClass
    {

        [StringLength(250)]
        public string ?FileName { get; set; }
        [StringLength(1000)]
        public string ?FilePath { get; set; }
        public int FolderId { get; set; }
        [StringLength(500)]
        public string? Description { get; set; }

        public int? FileExtensionMappingId { get; set; }

        [ForeignKey("FileExtensionMappingId")]
        public virtual FileExtensionMapping ?FileExtensionMapping { get; set; }

        [ForeignKey("FolderId")]
        public virtual Folder ?Folder { get; set; }


        [NotMapped] // Exclude this property from database mapping
        public IFormFile ?FileUpload { get; set; }
    }
}
