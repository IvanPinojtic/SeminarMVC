using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SeminarMVC.Models
{
    public class Context:DbContext
    {
        public Context() : base("Context") { }
        public static Context Create()
        {
            return new Context();
        }
        public DbSet<Restoran> Restorans { get; set; }
        public DbSet<Grad> Grads { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Menu> Menus { get; set; }
    }
}