using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using UPLOADFILE_FOLDER_PORTAL.Models;

namespace UPLOADFILE_FOLDER_PORTAL.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //}
        public DbSet<Category> Category { get; set; }
        public DbSet<Folder> Folder { get; set; }
        public DbSet<Files> Files { get; set; }
        public DbSet<FileExtensionMapping> FileExtensionMappings { get; set; }
        public DbSet<Department>departments { get; set; }
    }
}