namespace SeminarMVC.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SeminarMVC.Models.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SeminarMVC.Models.Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Grads.AddOrUpdate(
                  p => p.Ime,
                  new Models.Grad { Drzava = "Hrvatska",Ime="Zagreb" },
                  new Models.Grad { Drzava = "Spain",Ime="Madrid" },
                  new Models.Grad { Drzava = "Hrvatska", Ime = "Split" },
                  new Models.Grad { Drzava = "Hrvatska", Ime = "Rijeka" }
                );
            context.Restorans.AddOrUpdate(
                  p => p.Ime,
                  new Models.Restoran { Adresa = "Ilica 30", Ime = "Kod Ilice", Kapacitet = 10, GradID = 1,Zvez=4 },
                  new Models.Restoran { Adresa = "Ilica 88", Ime = "Maricini kolaci", Kapacitet = 12, GradID = 1 ,Zvez=2}
                );
            context.Menus.AddOrUpdate(
                  p => p.Ime,
                  new Models.Menu { Cijena = 20, Ime = "Grah" ,RestoranID=1},
                  new Models.Menu { Cijena = 10, Ime = "Salata" ,RestoranID=1}
                );
                 
            context.Staffs.AddOrUpdate(
                  p => p.Ime,
                  new Models.Staff { Pozicija = "Kuhar", Ime = "Ivo Ivic", Zvez = 0, RestoranID = 1 },
                  new Models.Staff { Pozicija = "Kuhar", Ime = "Marko Marulic", Zvez = 2, RestoranID = 2 }
                );
                
       
            //
        }
    }
}
