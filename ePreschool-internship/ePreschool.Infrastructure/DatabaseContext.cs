using ePreschool.Core.Entities;
using ePreschool.Core.Entities.Identity;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ePreschool.Infrastructure
{
    public partial class DatabaseContext :  IdentityDbContext<ApplicationUser, ApplicationRole, int, ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin, ApplicationRoleClaim, ApplicationUserToken>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options):
            base(options) 
        {
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Preschool> Preschools { get; set; }

        public DbSet<BusinessUnit> BusinessUnits { get; set; }
        public DbSet<BusinessUnitProgram> BusinessUnitPrograms { get; set; }
        public DbSet<Child> Children { get; set; }
        public DbSet<Parent> Parents { get; set; }
        public DbSet<ParentChild> ParentChildren { get; set; }
        public DbSet<WorkingProgram> Programs { get; set; }
        public DbSet<Log> Logs { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }     
    }
}