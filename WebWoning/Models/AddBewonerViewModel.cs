using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace WebWoning.Models
{
    public class AddBewonerViewModel
    {
        public AddBewonerViewModel()
        {
            Woning = new List<SelectListItem>();
        }
        public string Naam { get; set; }
        public int GetWoningId()
        {
            return int.Parse(SelectedWoning);
        }
        public List<SelectListItem> Woning{ get; }
        public string SelectedWoning { get; set; }
    }
}