using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UPLOADFILE_FOLDER_PORTAL.Models
{
    public class Category:BaseClass
    {
        [StringLength(250)]
        public string Name { get; set; }
        public int? Main_Cat_Id { get; set; }
        [StringLength(500)]
        public string? Description { get; set; }
        [ForeignKey("Main_Cat_Id")]
       public virtual Category ?category { get; set; }

        public ICollection<Folder>?folders { get; set; }

        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public virtual Department ?Department  { get; set; }
        public string? RoleId { get; set; }
        [ForeignKey("RoleId")]
        public virtual IdentityRole ?Role { get; set; }

    }
}
