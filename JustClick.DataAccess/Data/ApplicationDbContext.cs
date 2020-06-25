using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using JustClick.Models;
using JustClick.Models.Identity;
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace JustClick.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>//, IDataProtectionKeyContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);

        //    //Change my AspNetUser table to User
        //    builder.Entity<IdentityUser>().ToTable("TBL_OFFICER");

        //    //Change my AspNetRoles to Role
        //    builder.Entity<IdentityRole>().ToTable("TBL_OFFICER");

        //}
        //public class ApplicationDbContext : IdentityDbContext
        //{
        //    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        //        : base(options)
        //    {
        //    }


        public DbSet<CreditCardTypeModel> TBL_CARDTYPE { get; set; }
        public DbSet<NonTargetModel> TBL_NONTARGET { get; set; }

        public DbSet<ProjectConfigModel> TBL_PROJECT_CONFIG { get; set; }

        public DbSet<DataProtectionKey> DataProtectionKeys { get; set; }


        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<TitleModel> TBL_TITLE { get; set; }

        public DbSet<RefuseModel> TBL_REFUSE { get; set; }

    }
}
