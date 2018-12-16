using NorthwindWebApp.DataAccessLayer;
using NorthwindWebApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NorthwindWebApp.BusinessLayer
{
    public class CategoriesBL
    {
        private CategoriesDAL _CategoriesDA { get; set; }

        public CategoriesBL() 
        {
            NORTHWNDEntities northWindEntity = new NORTHWNDEntities();
            _CategoriesDA = new CategoriesDAL(northWindEntity);
        }

        public IEnumerable<Categories> GetAll()
        {
            try
            {

                IEnumerable<Categories> catagory_s;
                catagory_s = _CategoriesDA.GetAll();
                return catagory_s;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public void Create(Categories catagory)
        {
            try
            {
                _CategoriesDA.Create(catagory);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



    }
}