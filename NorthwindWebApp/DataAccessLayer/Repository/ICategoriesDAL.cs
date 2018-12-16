using NorthwindWebApp.Models;
using NorthwindWebApp.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindWebApp.DataAccessLayer
{
    public interface ICategoriesDAL :IAutoInject
    {
        IEnumerable<Categories> GetAll();
        Categories Get(int? categoryID);
        void Create(Categories instance);
        void Update(Categories instance);
        void Delete(Categories instance);
    }
}
