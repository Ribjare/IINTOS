using IINTOS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IINTOS.Data
{
    public class DbInitializer
    {
        public static async Task Initialize(IINTOSContext context, UserManager<User> userManager, IServiceProvider serviceProvider)
        {
            context.Database.EnsureCreated();
            if ( /*NOT*/ !context.Country.Any())
            {
                // Adds Country dor tests
                context.Country.Add(new Country {Name="Portugal" });
                context.Country.Add(new Country { Name = "Italy" });
                context.Country.Add(new Country { Name = "Czech Republic" });


                context.SaveChanges();
            }
            if ( /*NOT*/ !context.Nationality.Any())
            {
                // Adds Country dor tests
                context.Nationality.Add(new Nationality { Name = "Portuguese" });
                context.Nationality.Add(new Nationality { Name = "Italian" });
                context.Nationality.Add(new Nationality { Name = "Czech" });


                context.SaveChanges();
            }

            if ( /*NOT*/ !context.Language.Any())
            {
                // Adds Languages for tests
                context.Language.Add(new Language { Name = "Portuguese" });


                context.SaveChanges();
            }
            if ( /*NOT*/ !context.School.Any())
            {
                // Adds School for tests
                context.School.Add(new School { Name= "ESTStubal", Address = "Rua do IPS", Website = "https://www.estsetubal.ips.pt/" });
                context.School.Add(new School { Name = "Palacký University Olomou", Address = "Křížkovského ", Website = "https://www.upol.cz/en/" });



                context.SaveChanges();
            }
            if (!context.Roles.Any())
            {
                // Creates the Roles

                await CreateRole("Admin", serviceProvider);
                await CreateRole("Coordinator", serviceProvider);
                await CreateRole("Professor", serviceProvider);



            }


        }

        private static async Task CreateRole(string role, IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var roleCheck = await roleManager.RoleExistsAsync(role);
            if (!roleCheck)
            {
                //create the roles and seed them to the database
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }

    }
}
