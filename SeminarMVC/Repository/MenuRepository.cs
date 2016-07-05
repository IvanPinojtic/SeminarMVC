using SeminarMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeminarMVC.Repository
{
    public class MenuRepository:RepositoryBase<Menu>
    {
        public MenuRepository(Context context) : base(context) { }
        public List<Menu> GetList()
        {
            return this.DbContext.Menus.OrderBy(p => p.ID).ToList();
        }
    }
}