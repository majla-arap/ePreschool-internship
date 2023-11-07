using ePreschool.Core;
using ePreschool.Core.Entities;
using ePreschool.Core.Entities.Identity;
using ePreschool.Core.Enumerations;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ePreschool.Infrastructure
{
    public partial class DatabaseContext
    {

        ModelBuilder modelBuilder;
        public DateTime dateTime { get; set; } = new DateTime(2022, 6, 10, 1, 22, 18, 866, DateTimeKind.Local);
        
        public void SeedData(ModelBuilder modelBuilder)
        {
            this.modelBuilder = modelBuilder;
            SeedRoles();
            SeedCountries();
            SeedCities();
            SeedApplicationUsers();
            SeedApplicationUserRoles();
            SeedCompanies();
            SeedBusinessUints();
            SeedProgram();
            SeedBusinessUnitProgram();
            SeedParents();
            SeedChildren();
            SeedParentChildern();
        }

        private void SeedProgram()
        {
            modelBuilder.Entity<WorkingProgram>().HasData(new WorkingProgram[]
             {
                 new WorkingProgram
                 {
                    Id = 1,
                    Name = "All day",
                    NumberOfHours = 10,
                    Description = "All day",
                    CreatedAt = dateTime,
                    ModifiedAt = null
                 },
                 new WorkingProgram
                 {
                    Id = 2,
                    Name = "Half day",
                    NumberOfHours = 5,
                    Description = "Half day",
                    CreatedAt = dateTime,
                    ModifiedAt = null
                 },
                 new WorkingProgram
                 {
                    Id = 3,
                    Name = "Nursery",
                    NumberOfHours = 10,
                    Description = "Nursery",
                    CreatedAt = dateTime,
                    ModifiedAt = null
                 },
                 new WorkingProgram
                 {
                    Id = 4,
                    Name = "Playroom",
                    NumberOfHours = 3,
                    Description = "Playroom",
                    CreatedAt = dateTime,
                    ModifiedAt = null
                 }
             });
        }

        private void SeedBusinessUnitProgram()
        {
            modelBuilder.Entity<BusinessUnitProgram>().HasData(new BusinessUnitProgram[]
             {
                 new BusinessUnitProgram
                 {
                    Id = 1,
                    BusinessUnitId= 1,
                    ProgramId= 1,
                    CreatedAt = dateTime,
                    ModifiedAt = null
                 }

            });
        }

        private void SeedParentChildern()
        {
            modelBuilder.Entity<ParentChild>().HasData(new ParentChild[]
              {
                 new ParentChild
                 {
                    Id = 1,
                    ParentId = 1,
                    ChildId = 1,
                    CreatedAt = dateTime,
                    ModifiedAt = null
                 }
              });
        }

        private void SeedParents()
        {
            modelBuilder.Entity<Parent>().HasData(new Parent[]
             {
                 new Parent
                 {
                    Id = 1,
                    UserId = 1,
                    FirstName = "Haris",
                    LastName = "Arap",
                    BirthDate = DateTime.Now,
                    PhoneNumber = "+387 61 333 333",
                    Email = "hara@gmail.com",
                    Employed = true,
                    EducationLevel = EducationLevel.MR,
                    CreatedAt = dateTime,
                    ModifiedAt = null
                 }
             });
        }

        private void SeedChildren()
        {
            modelBuilder.Entity<Child>().HasData(new Child[]
            {
                 new Child
                 {
                    Id = 1,
                    FirstName = "Majla",
                    LastName = "Arap",
                    BirthDate = DateTime.Now,
                    CityOfBirthId = 2,
                    CountryOfBirthId = 1,
                    FamilyMembers = 4,
                    Adress = "test1",
                    PreschoolId = 1,
                    BusinessUnitId = 1,
                    AlternativeBusinessUnitId = 2,
                    ProgramId = 1,
                    CreatedAt = dateTime,
                    ModifiedAt = null
                 },
                 new Child
                 {
                    Id = 2,
                    FirstName = "Ajla",
                    LastName = "Arap",
                    BirthDate = DateTime.Now,
                    CityOfBirthId = 2,
                    CountryOfBirthId = 1,
                    FamilyMembers = 4,
                    Adress = "S3",
                    PreschoolId = 1,
                    BusinessUnitId = 1,
                    AlternativeBusinessUnitId = 2,
                    ProgramId = 1,
                    CreatedAt = dateTime,
                    ModifiedAt = null
                 }
            });
        }

        private void SeedCountries()
        {
            modelBuilder.Entity<Country>().HasData(new Country[]
        {
                new Country
                {
                    Id = 1,
                    Name = "Bosna i Hercegovina",
                    Abbreviation="BIH",
                    IsFavorite = true,
                    CreatedAt = dateTime,
                    ModifiedAt = null
                },
                new Country
                {
                    Id = 2,
                    Name = "Hrvatska",
                    Abbreviation="HR",
                    CreatedAt = dateTime,
                    ModifiedAt = null
                },
                new Country
                {
                    Id = 3,
                    Name = "Srbija",
                    Abbreviation="SR",
                    CreatedAt = dateTime,
                    ModifiedAt = null
                },
                new Country
                {
                    Id = 4,
                    Name = "Crna Gora",
                    Abbreviation="CG",
                    CreatedAt = dateTime,
                    ModifiedAt = null
                },
                new Country
                {
                    Id = 5,
                    Name = "Slovenija",
                    Abbreviation="SLO",
                    CreatedAt = dateTime,
                    ModifiedAt = null
                },
                new Country
                {
                    Id = 6,
                    Name = "Austrija",
                    Abbreviation="A",
                    CreatedAt = dateTime,
                    ModifiedAt = null
                },
                 new Country
                {
                    Id = 7,
                    Name = "Makedonija",
                    Abbreviation="MKD",
                    CreatedAt = dateTime,
                    ModifiedAt = null
                },
        });
        }
        private void SeedCities()
        {
            modelBuilder.Entity<City>().HasData(new City[]
        {
                new City
                {
                    Id = 1,
                    CountryId = 1,
                    Name = "Sarajevo",
                    CreatedAt = dateTime,
                    ModifiedAt = null
                },
               new City
                {
                    Id = 2,
                    CountryId = 1,
                    Name = "Mostar",
                    IsFavorite = true,
                    CreatedAt = dateTime,
                    ModifiedAt = null
                },
               new City
                {
                    Id = 3,
                    CountryId = 1,
                    Name = "Tuzla",
                    CreatedAt = dateTime,
                    ModifiedAt = null
                },
               new City
                {
                    Id = 4,
                    CountryId = 1,
                    Name = "Zenica",
                    CreatedAt = dateTime,
                    ModifiedAt = null
                },
               new City
                {
                    Id = 5,
                    CountryId = 1,
                    Name = "Bihać",
                    CreatedAt = dateTime,
                    ModifiedAt = null
                },
                  new City
                {
                    Id = 6,
                    CountryId = 2,
                    Name = "Zagreb",
                    CreatedAt =dateTime,
                    ModifiedAt = null
                },
                     new City
                {
                    Id = 7,
                    CountryId = 2,
                    Name = "Split",
                    CreatedAt = dateTime,
                    ModifiedAt = null
                },
        });
        }
        private void SeedCompanies()
        {
            modelBuilder.Entity<Preschool>().HasData(new List<Preschool>
            {
                new Preschool
                {
                    Id = 1,
                    Name = "ZemZem",
                    Address = "Sjeverni Logor 12",
                    Email = "zemzem@gmail.com",
                    TaxNumber = "65487978654654",
                    PostalCode = "88208",
                    PhoneNumber = "+387 36 222 333",
                    Active = true,
                    CreatedAt = dateTime
                },
                new Preschool
                {
                    Id = 2,
                    Name = "Djecija radost",
                    Address = "Alekse Šantića 5",
                    Email = "djecija.radost@gmail.com",
                    TaxNumber = "65487978654654",
                    PostalCode = "88208",
                    PhoneNumber = "+387 36 222 333",
                    Active = true,
                    CreatedAt = dateTime
                }
            });
        }
        private void SeedBusinessUints()
        {
            modelBuilder.Entity<BusinessUnit>().HasData(new List<BusinessUnit>
            {
                new BusinessUnit
                {
                    Id = 1,
                    PreschoolId = 1,
                    Name = "ZemZem Sjeveni",
                    Address = "Sjeverni Logor 12",
                    Email = "zemzem_sjeverni@gmail.com",
                    PostalCode = "88208",
                    PhoneNumber = "+387 36 333 333",
                    IDNumber = "643218645312",
                    Active = true,
                    CreatedAt = dateTime
                },
                new BusinessUnit
                {
                    Id = 2,
                    PreschoolId = 1,
                    Name = "ZemZem Zalik",
                    Address = "Zalik 12b",
                    Email = "zemzem_zalik@gmail.com",
                    PostalCode = "88208",
                    PhoneNumber = "+387 36 111 333",
                    IDNumber = "985518645312",
                    Active = true,
                    CreatedAt = dateTime
                },             
            });
        }
        private void SeedApplicationUsers()
        {
            modelBuilder.Entity<ApplicationUser>().HasData(new ApplicationUser[] {
                new ApplicationUser {
                    Id = 1,
                    FirstName="Admin",
                    LastName="PreSchool",
                    Gender = Gender.Male,
                    CityId=1,
                    UserName = "admin",
                    NormalizedUserName = "ADMIN",
                    Email = "admin@preschool.ba",
                    NormalizedEmail = "ADMIN@PRESCHOOL.BA",
                    PasswordHash = "/jgjzf1nC8YDuZMV5q0kYrRqIarjCDgWjBERaZiyyO0=",
                    PasswordSalt = "DFQVcTkMv8qWjq/5ars8Eg==",
                    EmailConfirmed=true,
                    ConcurrencyStamp = "9547f983-1707-49d3-9390-5ec84ec35dca",
                    IsDeleted = false,
                    CreatedAt = dateTime                        
                },
                 new ApplicationUser {
                    Id = 2,
                    FirstName="Manager",
                    LastName="PreSchool",
                    Gender = Gender.Male,
                    CityId=1,
                    UserName = "manager",
                    NormalizedUserName = "MANAGER",
                    Email = "manager@preschool.ba",
                    NormalizedEmail = "MANAGER@PRESCHOOL.BA",
                    PasswordHash = "/jgjzf1nC8YDuZMV5q0kYrRqIarjCDgWjBERaZiyyO0=",
                    PasswordSalt = "DFQVcTkMv8qWjq/5ars8Eg==",
                    EmailConfirmed=true,
                    ConcurrencyStamp = "9547f983-1707-49d3-9390-5ec84ec35dca",
                    IsDeleted = false,
                    CreatedAt = dateTime
                },
            });
        }
        private void SeedApplicationUserRoles()
        {
            modelBuilder.Entity<ApplicationUserRole>().HasData(new List<ApplicationUserRole>
            {
                new ApplicationUserRole
                {
                    Id = 1,
                    UserId = 1,
                    RoleId = (int)Role.SuperAdministrator,
                    CreatedAt = dateTime
                },
                 new ApplicationUserRole
                {
                    Id = 2,
                    UserId = 2,
                    RoleId = (int)Role.PreschoolManagement,
                    PreschoolId = 1,
                    CreatedAt = dateTime
                },
               
            });
        }
        private void SeedRoles()
        {
            modelBuilder.Entity<ApplicationRole>().HasData(Enum.GetValues(typeof(Role)).Cast<Role>().Select(role => new ApplicationRole
            {
                Id = (int)role,
                Name = role.ToString(),
                RoleLevel = (int)role == (int)Role.SuperAdministrator ? (int?)null : (int)role - 1,
                NormalizedName = role.ToString().ToUpper(),
                ConcurrencyStamp = $"{(int)role}547f983-1707-49d3-9390-5ec84ec35dca",
                CreatedAt = dateTime
            }).ToList());
        }
    }
}
