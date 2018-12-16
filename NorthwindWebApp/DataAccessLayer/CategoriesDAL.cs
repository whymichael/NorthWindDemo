using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using NorthwindWebApp.Models.Entities;

namespace NorthwindWebApp.DataAccessLayer
{
    public class CategoriesDAL : IDisposable
    {

        private DbContext _EF = null;
        public CategoriesDAL(DbContext EF)
        {
            try
            {
                if (this._EF == null)
                {
                    this._EF = EF;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public IEnumerable<Categories> GetAll()
        {
            try
            {
                return _EF.Set<Categories>().ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void Create(Categories instance)
        {
            if (instance == null)
            {
                throw new ArgumentNullException("instance");
            }
            else
            {
                _EF.Set<Categories>().Add(instance);
                this.SaveChanges();
            }
        }


        public void SaveChanges()
        {
            this._EF.SaveChanges();
        }


        private bool disposed = false;

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposing)
            {
                return;
            }
            if (this._EF == null)
            {
                return;
            }
            this._EF.Dispose();
            this._EF = null;
        }


    }
}