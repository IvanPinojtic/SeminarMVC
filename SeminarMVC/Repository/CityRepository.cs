using SeminarMVC.Models;
using SeminarMVC.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeminarMVC.Repository
{
    public class CityRepository:RepositoryBase<Grad>
    {
        public CityRepository(Context context) : base(context) { }
        public List<Grad> GetList()
        {
            return this.DbContext.Grads.OrderBy(p => p.ID).ToList();
        }
    }
}