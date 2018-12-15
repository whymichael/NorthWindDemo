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
        public CategoriesDAL _CategoriesDA { get; set; }


        public IEnumerable<Categories> GetAll()
        {
            try
            {
                NORTHWNDEntities northWindEntity = new NORTHWNDEntities();
                _CategoriesDA = new CategoriesDAL(northWindEntity);

                IEnumerable<Categories> catagory_s;
                catagory_s = _CategoriesDA.GetAll();
                return catagory_s;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


    }
}