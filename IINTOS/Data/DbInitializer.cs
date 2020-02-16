using IINTOS.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace IINTOS.Data
{
    public class DbInitializer
    {
        private class CountryJson
        {
            public string name { get; set; }

        }
        private class StateJson
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int country_id { get; set; }
        }
        private class CityJson
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int state_id { get; set; }
        }

        public static async Task Initialize(IINTOSContext context, UserManager<User> userManager, IServiceProvider serviceProvider)
        {
            context.Database.EnsureCreated();


            if ( /*NOT*/ !context.Country.Any())
            {

                using (StreamReader r = new StreamReader("Raw/countries.json"))
                {
                    string json = r.ReadToEnd();
                    List<CountryJson> items = JsonConvert.DeserializeObject<List<CountryJson>>(json);

                    foreach (var x in items)
                    {
                        var newCountry = new Country
                        {
                            Name = x.name,
                        };

                        context.Add(newCountry);
                    }
                }

                context.SaveChanges();
            }
            /*
            if (!context.State.Any())
            {

                using (StreamReader r = new StreamReader("raw/states.json"))
                {
                    string json = r.ReadToEnd();
                    List<StateJson> items = JsonConvert.DeserializeObject<List<StateJson>>(json);

                    foreach (var x in items)
                    {
                        Console.WriteLine("----------------- " + x.country_id);

                        int id = x.country_id;
                        var country = context.Country.Where(p => p.Id == id).FirstOrDefault();

                        var newState = new State
                        {
                            Name = x.Name,
                            Country = country
                        };

                        context.Add(newState);

                    }
                    context.SaveChanges();

                }

            }
            if (!context.City.Any())
            {
                using (StreamReader r = new StreamReader("raw/cities.json"))
                {
                    string json = r.ReadToEnd();
                    List<CityJson> items = JsonConvert.DeserializeObject<List<CityJson>>(json);

                    foreach (var x in items)
                    {
                        var state = context.State.Where(p => p.Id == x.state_id).FirstOrDefault();

                        var newCity = new City
                        {
                            Name = x.Name,
                            State = state
                        };

                        context.Add(newCity);
                    }
                }

                context.SaveChanges();
            }*/
            if ( /*NOT*/ !context.Language.Any())
            {
                // Adds Languages for tests
                context.Language.Add(new Language { Name = "Portuguese" });


                context.SaveChanges();
            }
            if ( /*NOT*/ !context.School.Any())
            {
                // Adds School for tests
                context.School.Add(new School { Name = "ESTStubal", Address = "Rua do IPS", Website = "https://www.estsetubal.ips.pt/", CountryId = 1 });
                context.School.Add(new School { Name = "Palacký University Olomou", Address = "Křížkovského ", Website = "https://www.upol.cz/en/", CountryId = 2 });



                context.SaveChanges();
            }
            if (!context.Roles.Any())
            {
                // Creates the Roles

                //System admin
                await CreateRole("Admin", serviceProvider);

                //Mobility Area
                await CreateRole("Coordinator", serviceProvider);
                await CreateRole("Professor", serviceProvider);
                await CreateRole("Guest-Professor", serviceProvider);

                //IINTOS Area
                //IINTOS-Coordinator
                await CreateRole("IINTOS-Coordinator", serviceProvider);
                //IINTOS-Professor
                await CreateRole("IINTOS-Professor", serviceProvider);
                context.SaveChanges();

            }
            if (!context.Users.Any())
            {
                // Admin
                User defaultUser = new User
                {
                    Name = "Admin Zé",
                    UserName = "iintosdev@hotmail.com",
                    Email = "iintosdev@hotmail.com",
                    EmailConfirmed = true,
                    About = "Admin default",
                    Active = true,
                    NationalityId = 1
                };


                // Coordenador IINTOS
                User coordenadorIINTOS = new User
                {
                    Name = "Coordenador Anturio",
                    UserName = "iceptalves@gmail.com",
                    Email = "iceptalves@gmail.com",
                    EmailConfirmed = true,
                    About = "Coordenador IINTOS default",
                    Active = true,
                    NationalityId = 1
                };


                try
                {
                    var result = await userManager.CreateAsync(defaultUser, "123456");
                    var result2 = await userManager.CreateAsync(coordenadorIINTOS, "123456");

                    if (result.Succeeded && result2.Succeeded)
                    {
                        //await userManager.AddToRoleAsync(defaultUser, "Coordinator");
                        await userManager.AddToRoleAsync(defaultUser, "Admin");

                        await userManager.AddToRoleAsync(coordenadorIINTOS, "IINTOS-Coordinator");


                    }
                    context.SaveChanges();

                }
                catch (Exception e)
                {

                }
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
