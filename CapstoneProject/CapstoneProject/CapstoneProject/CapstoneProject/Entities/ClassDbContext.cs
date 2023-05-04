using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using CapstoneProject.Controllers;
using CapstoneProject.Entities;
using CapstoneProject.Models;
using Microsoft.AspNetCore.Identity;

namespace CapstoneProject.DataAccess
{
    public class ClassDbContext : IdentityDbContext<User>
    {
        public static async Task CreateAdminUser(IServiceProvider serviceProvider)
        {
            UserManager<User> userManager =
                serviceProvider.GetRequiredService<UserManager<User>>();
            RoleManager<IdentityRole> roleManager = serviceProvider
                .GetRequiredService<RoleManager<IdentityRole>>();

            string username = "admin";
            string password = "Owner123#";
            string roleName = "Admin";

            // if role doesn't exist, create it
            if (await roleManager.FindByNameAsync(roleName) == null)
            {
                await roleManager.CreateAsync(new IdentityRole(roleName));
            }
            // if username doesn't exist, create it and add it to role
            if (await userManager.FindByNameAsync(username) == null)
            {
                User user = new User { UserName = username };
                var result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, roleName);
                }
            }
        }
        public ClassDbContext(DbContextOptions<ClassDbContext> options) : base(options)
        {

        }

        public DbSet<Class> Classes { get; set; }
        public DbSet<Instructor> Instructorss { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<Province> Provinces { get; set; }
        public DbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Class>()
            .HasMany(c => c.Clients)
            .WithOne(cl => cl.Class)
            .HasForeignKey(cl => cl.ClassId);

            modelBuilder.Entity<Class>() // updated entity configuration
         .HasMany(c => c.Instructors)
         .WithOne(i => i.Class)
         .HasForeignKey(i => i.ClassId);




            modelBuilder.Entity<Instructor>().HasData(
                new Instructor() { InstructorId = 1, InstructorAddress = "9 pleasant avenue", InstructorPostalCode = "N2M 4A3", InstructorPhoneNumber = 6477808766, InstructorName = "Bob jones", ClassId = 1, },

                new Instructor() { InstructorId = 2, InstructorAddress = "4 king street east", InstructorPostalCode = "N2M 4H7", InstructorPhoneNumber = 989898989898, InstructorName = "jasmine", ClassId = 2, },

            new Instructor() { InstructorId = 3, InstructorAddress = "40 pincrest avenue", InstructorPostalCode = "N2M 4B5", InstructorPhoneNumber = 1212121212, InstructorName = "Harshita", ClassId = 3, },
             new Instructor() { InstructorId = 4, InstructorAddress = "22 queen avenue", InstructorPostalCode = "N2M 1B1", InstructorPhoneNumber = 1111111111, InstructorName = "Jatin", ClassId = 1, }
                );

            modelBuilder.Entity<Client>().HasData(
             new Client() { ClientId = 1, ClientAddress = "9o pnmleasant avenue", ClientPostalCode = "N2M 4L3", ClientPhoneNumber = 6477808766, ClientName = "sahil", ClassId = 1 },

             new Client() { ClientId = 2, ClientAddress = "67 queen street east", ClientPostalCode = "N2M 9L7", ClientPhoneNumber = 989898989898, ClientName = "raghav", ClassId = 1 },

         new Client() { ClientId = 3, ClientAddress = "20 newway avenue", ClientPostalCode = "N2M 9r9", ClientPhoneNumber = 1212121212, ClientName = "jj", ClassId = 2 },
         new Client() { ClientId = 4, ClientAddress = "40 newway avenue", ClientPostalCode = "N2M 9O9", ClientPhoneNumber = 1212121212, ClientName = "jass", ClassId = 3 }
             );


            modelBuilder.Entity<Class>().HasData(
                new Class() { ClassId = 1, ClassPrice = 34, ClassName = "Times Square,NY" },
                new Class() { ClassId = 2, ClassPrice = 24, ClassName = "Moe`s Bar, Springfield" },
                   new Class() { ClassId = 3, ClassPrice = 29, ClassName = "Springfield" }
                );
            modelBuilder.Entity<Country>().HasData(
               new Country() { CountryId = 1,  CountryName = "Canada" },
               new Country() { CountryId = 2,  CountryName = "India" },
                  new Country() { CountryId = 3, CountryName = "USA" }
               );
            modelBuilder.Entity<Province>().HasData(
               new Province() { ProvinceId = 1, ProvinceName = "Ontario" },
               new Province() { ProvinceId = 2, ProvinceName = "Haryana" },
                  new Province() { ProvinceId = 3, ProvinceName = "Quebec" }
               );
            modelBuilder.Entity<Facility>().HasData(
              new Facility() { FacilityId = 1, Name = "Tiger`s Gym",Address ="1 Univeristy avenue"},
              new Facility() { FacilityId = 2, Name = "Lion`s Gym" ,Address="Sec 19 Kaithal"},
                 new Facility() { FacilityId = 3, Name = "Power Gym" ,Address= "1201 W Centerville Rd, Garland TX 75041" }
              );
        }
    }
}

