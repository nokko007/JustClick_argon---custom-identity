using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using JustClick.Models;
using JustClick.Models.Identity;
using Microsoft.AspNetCore.DataProtection.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace JustClick.DataAccess.Data
{
    public class ApplicationDbContextRenew : IdentityDbContext<ApplicationUser>//, IDataProtectionKeyContext
    {
        public ApplicationDbContextRenew(DbContextOptions<ApplicationDbContextRenew> options)
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


        public DbSet<SuccessModel> TBL_SUCCESS { get; set; }

        public DbSet<CallbackModel> TBL_CALLBACK { get; set; }
        public DbSet<FailModel> TBL_FAIL { get; set; }

        public DbSet<IDCardTypeModel> TBL_IDCARD { get; set; }

        public DbSet<BankModel> TBL_BANK { get; set; }

        public DbSet<ScriptModel> TBL_SCRIPT { get; set; }

        public DbSet<IntranetModel> TBL_INTRANET { get; set; }

    }

   

}
