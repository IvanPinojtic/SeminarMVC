using SeminarMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeminarMVC.Repository
{
    public class StaffRepository : RepositoryBase<Staff>
    {
        public StaffRepository(Context context) : base(context)
        {

        }
        public List<Staff> GetList()
        {
            return this.DbContext.Staffs.OrderBy(p => p.ID).ToList();
        }
    }
}