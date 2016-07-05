using SeminarMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SeminarMVC.Repository
{
    public abstract class RepositoryBase<TEntity>
        where TEntity:Base
    {
        protected Context DbContext { get; }
        public RepositoryBase(Context context)
        {
            this.DbContext = context;
        }
        public virtual TEntity Find(int id)
        {
            return this.DbContext.Set<TEntity>()
                .Where(p => p.ID == id)
                .FirstOrDefault();
        }
        public void Add(TEntity model,bool autoSave = false)
        {
            this.DbContext.Set<TEntity>().Add(model);
            if (autoSave) this.Save();
        }
        public void Update(TEntity model, bool autoSave = false)
        {

            this.DbContext.Entry(model).State = EntityState.Modified;

            if (autoSave)
                this.Save();
        }

        public virtual void Delete(int id, bool autoSave = false)
        {
            var entity = this.DbContext.Set<TEntity>().Find(id);
            this.DbContext.Entry(entity).State = EntityState.Deleted;

            if (autoSave)
                this.Save();
        }

        public void Save()
        {
            this.DbContext.SaveChanges();
        }
    }
}