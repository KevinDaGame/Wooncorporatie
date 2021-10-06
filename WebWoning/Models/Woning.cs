using System.Collections.Generic;

namespace WebWoning.Models
{
    public class Woning
    {

        public List<Bewoner> Bewoners { get; set; }
        public int Id{ get; set; }
        public string Naam{ get; set; }
        

        public Woning()
        {
            Bewoners = new List<Bewoner>();
        }
    }
}