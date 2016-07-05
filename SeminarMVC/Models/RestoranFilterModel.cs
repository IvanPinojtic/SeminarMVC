using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeminarMVC.Models
{
    public class RestoranFilterModel:IRestoranFilter
    {
        public string Ime { get; set; }
        public int? Zvez { get; set; }
        public string Adresa { get; set; }
        public string CityName { get; set; }
    }
}