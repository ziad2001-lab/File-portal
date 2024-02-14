using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UPLOADFILE_FOLDER_PORTAL.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int DepartmentId { get; set; }


        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department? Department { get; set; }
    }
}
