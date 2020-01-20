using IINTOS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IINTOS.Data
{
    public class DbInitializer
    {
        public static async Task Initialize(IINTOSContext context)
        {
            context.Database.EnsureCreated();
            if ( /*NOT*/ !context.Country.Any())
            {
                // Adds Country dor tests
                context.Country.Add(new Country {Name="Portugal" });
                context.Country.Add(new Country { Name = "Italy" });
                context.Country.Add(new Country { Name = "Czech Republic" });


                context.SaveChanges();
                //antes de se usar as FK das marcas na adicão de carros, 
                //tem que se chamar SaveChanges, ou daria um "FK error"
            }
            if ( /*NOT*/ !context.Nationality.Any())
            {
                // Adds Country dor tests
                context.Nationality.Add(new Nationality { Name = "Portuguese" });
                context.Nationality.Add(new Nationality { Name = "Italian" });
                context.Nationality.Add(new Nationality { Name = "Czech" });


                context.SaveChanges();
                //antes de se usar as FK das marcas na adicão de carros, 
                //tem que se chamar SaveChanges, ou daria um "FK error"
            }

            if ( /*NOT*/ !context.Language.Any())
            {
                // Adds Languages for tests
                context.Language.Add(new Language { Name = "Portuguese" });


                context.SaveChanges();
                //antes de se usar as FK das marcas na adicão de carros, 
                //tem que se chamar SaveChanges, ou daria um "FK error"
            }
            if ( /*NOT*/ !context.School.Any())
            {
                // Adds School for tests
                context.School.Add(new School { Name= "ESTStubal", Address = "Rua do IPS", Website = "https://www.estsetubal.ips.pt/" });
                context.School.Add(new School { Name = "Palacký University Olomou", Address = "Křížkovského ", Website = "https://www.upol.cz/en/" });



                context.SaveChanges();
                //antes de se usar as FK das marcas na adicão de carros, 
                //tem que se chamar SaveChanges, ou daria um "FK error"
            }


        }

    }
}
