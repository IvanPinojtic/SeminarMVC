using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SeminarMVC.Models
{
    public class Staff:Base
    {
        [Required]
        public string Pozicija { get; set; }
        [Range(0,3,ErrorMessage ="0 do 3 zvijezdice")]
        public int Zvez { get; set; }
        public Restoran Restoran { get; set; }
        [ForeignKey("Restoran")]
        public int RestoranID { get; set; }
    }
}