using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data
{
    public class WoningRepo
    {
        public List<Woning> GetAll()
        {
            List<Woning> woningen;
            using(var ctx = new WoningContext())
            {
                woningen = ctx.Woning.Include(w => w.Bewoners).ToList();
            }
            return woningen;
        }

        public void AddBewonerToWoning(int v, string naam)
        {
            using(var ctx = new WoningContext())
            {
                var woning = ctx.Woning.FirstOrDefault(w => w.Id == v);
                woning.Bewoners.Add(new Bewoner() { Naam = naam });
                ctx.SaveChanges();
            }
        }
    }
}
