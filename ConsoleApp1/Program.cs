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
            var woningen = context.Woning.Include(w => w.Bewoners).ToList();
            foreach(var woning in woningen)
            {
                Console.WriteLine(woning.Bewoners[0].Naam);
            }
            Console.ReadLine();
        }

        private static void InsertData(WoningContext context)
        {
            context.Woning.Add(
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
            var woning = context.Woning.Include(w => w.Bewoners).FirstOrDefault(w => w.Id == 4);
            var bewoner = woning.Bewoners[0];
            bewoner.Naam = "Astrid";
            context.Bewoner.Update(bewoner);
            context.SaveChanges();
        }

        private static void DisconnectedUpdateVoorbeeld()
        {

            List<Bewoner> bewoners;

            using(var ctx = new WoningContext())
            {
                var woningen = ctx.Woning.Include(w => w.Bewoners).FirstOrDefault(w => w.Id == 4);
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
