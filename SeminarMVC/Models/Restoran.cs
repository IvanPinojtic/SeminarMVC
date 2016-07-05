using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace SeminarMVC.Models
{
    public class Restoran:Base
    {
        public string Adresa { get; set; }
        [Range(1,int.MaxValue , ErrorMessage = "mora biti vece od 1")]
        public int Kapacitet { get; set; }
        [Range(0, 6, ErrorMessage = "0 do 6 zvijezdica")]
        public int Zvez { get; set; }
        public virtual ICollection<Staff> Staffs { get; set;}
        public virtual ICollection<Menu> Menus { get; set; }
        [ForeignKey("Grad")]
        public int GradID { get; set; }
        public Grad Grad { get; set; }
    }
}