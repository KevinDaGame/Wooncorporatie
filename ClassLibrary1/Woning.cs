using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Data
{
    public class Woning
    {
        public Woning()
        {
        Bewoners = new List<Bewoner>();
        }

        public int Id { get; set; }
        public string Naam { get; set; }
        public List<Bewoner> Bewoners { get; set; }
        public int Huisnummer { get; set; }
    }


}
