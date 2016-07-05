using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeminarMVC.Models
{
    public class RestoranDTO
    {
        public int Id { get; set; }

        public string Ime { get; set; }

        public string Adresa { get; set; }

        public int GradID { get; set; }

        public int Zvez { get; set; }

        public int Kapacitet { get; set; }

        public string CityName { get; set; }
    }
}