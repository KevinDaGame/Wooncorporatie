using Company.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WoningConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var context = new WoningContext())
            {
                //GetWoningen(context);
                //InsertData(context);
                UpdateRelatedData(context);
            }
        }

        private static void GetWoningen(WoningContext context)
        {
            var woningen = context.Woningen.Include(w => w.Bewoners).ToList();
            foreach(var woning in woningen)
            {
                Console.WriteLine(woning.Bewoners[0].Naam);
            }
            Console.ReadLine();
        }

        private static void InsertData(WoningContext context)
        {
            context.Woningen.Add(
                new Woning
                {
                    Naam = "leeg huis",
                    Huisnummer = 12,
                    Bewoners = new List<Bewoner>
                    {
                        new Bewoner{Naam = "Jopie"},
                        new Bewoner{Naam = "Jan"}
                    }
                });
            context.SaveChanges();
        }

        private static void UpdateRelatedData(WoningContext context)
        {
            var woning = context.Woningen.Include(w => w.Bewoners).FirstOrDefault(w => w.ID == 4);
            var bewoner = woning.Bewoners[0];
            bewoner.Naam = "Astrid";
            context.Bewoners.Update(bewoner);
            context.SaveChanges();
        }

        private static void DisconnectedUpdateVoorbeeld()
        {

            List<Bewoner> bewoners;

            using(var ctx = new WoningContext())
            {
                var woningen = ctx.Woningen.Include(w => w.Bewoners).FirstOrDefault(w => w.ID == 4);
                bewoners = woningen.Bewoners;
            }
            bewoners[0].Naam = "Nieuwe student";
            using (var context = new WoningContext())
            {
                context.Entry(bewoners[0]).State = EntityState.Modified;
                context.SaveChanges();
            }

        }
    }
}
