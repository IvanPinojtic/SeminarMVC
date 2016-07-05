using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SeminarMVC.Models
{
    public class Grad:Base
    {
        [Required]
        public string Drzava { get; set; }
        public virtual ICollection<Restoran> Restorans { get; set; }
    }
}