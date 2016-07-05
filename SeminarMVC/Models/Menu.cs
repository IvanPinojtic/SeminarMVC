using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SeminarMVC.Models
{
    public class Menu:Base
    {   
        [Required]
        [Range(0,500,ErrorMessage ="izmedju 0 i 500")]
        public int Cijena { get; set; }
        [ForeignKey("Restoran")]
        public int RestoranID { get; set; }
        public Restoran Restoran { get; set; }
    }
}