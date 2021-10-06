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
    }
}
