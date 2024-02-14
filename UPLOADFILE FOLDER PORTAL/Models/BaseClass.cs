using System.ComponentModel.DataAnnotations;

namespace UPLOADFILE_FOLDER_PORTAL.Models
{
    public class BaseClass
    {
        [Key]
        public int Id { get; set; }
        [StringLength(250)]
        public string Createdby { get; set; }
        public DateTime Createddate { get; set; }
        [StringLength(250)]
        public string? Modifiedby { get; set; }
        public DateTime? Modifieddate { get; set; }
        public bool IsVisable { get; set; }
        public bool IsActive { get; set; }
    }
}
