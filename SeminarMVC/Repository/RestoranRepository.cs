using SeminarMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SeminarMVC.Repository
{
    public class RestoranRepository:RepositoryBase<Restoran>
    {
        public RestoranRepository(Context context) : base(context) { }
        public RestoranDTO GetDTO(int id)
        {
            return this.DbContext.Restorans
                .Where(p => p.ID == id).
                Select(p => new RestoranDTO() {
                    Adresa = p.Adresa,
                    Ime = p.Ime,
                    GradID=p.GradID,
                    Kapacitet=p.Kapacitet,
                    Zvez=p.Zvez,
                    CityName=p.Grad.Ime,
                    Id=p.ID
                }).FirstOrDefault();
        }

        public List<RestoranDTO> GetAllDTO(string q = null)
        {
            return this.DbContext.Restorans
                .Where(p => q == null || p.Ime.Contains(q))
                .Select(p => new RestoranDTO()
                {
                    Adresa = p.Adresa,
                    Ime = p.Ime,
                    GradID = p.GradID,
                    Kapacitet = p.Kapacitet,
                    Zvez = p.Zvez,
                    CityName = p.Grad.Ime,
                    Id = p.ID
                })
                .ToList();
        }

        public List<Restoran> GetList(IRestoranFilter filter)
        {
            var restoransQuery = this.DbContext.Restorans
                .Include(p => p.Grad)
                .AsQueryable();
            var abc = filter?.Zvez;
            if (!string.IsNullOrWhiteSpace(filter?.Ime))
                restoransQuery = restoransQuery.Where(p => p.Ime.Contains(filter.Ime));

            if (!string.IsNullOrWhiteSpace(filter?.Adresa))
                restoransQuery = restoransQuery.Where(p => p.Adresa.Contains(filter.Adresa));
            
            if (!string.IsNullOrWhiteSpace(filter?.CityName))
                restoransQuery = restoransQuery.Where(p => p.Grad.Ime.Contains(filter.CityName));

            // if((filter?.Zvez)<=6 && (filter?.Zvez) >= 0)
            if (!string.IsNullOrWhiteSpace(filter?.Zvez.ToString()))
                restoransQuery = restoransQuery.Where(p => p.Zvez==(filter.Zvez));
            
            return restoransQuery.OrderBy(p => p.ID).ToList();
        }
        
        public override Restoran Find(int id)
        {
            return this.DbContext.Restorans
                .Include(p => p.Grad)
                .Where(p => p.ID == id)
                .FirstOrDefault();
        }
    }
}