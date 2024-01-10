using System.ComponentModel.DataAnnotations;

namespace UPLOADFILE_FOLDER_PORTAL.Models
{
    public class Department:BaseClass
    {
        [StringLength(250)]
        public string ?DepartmenName { get; set; }
    }
}
